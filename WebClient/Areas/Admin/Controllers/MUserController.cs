using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text.Json;
using WebClient.Areas.SendMail.Models;
using WebClient.Data;
using ApplicationDbContext = WebClient.Data.ApplicationDbContext;

namespace WebClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MUserController : Controller
    {
        private readonly HttpClient client = null;
        private string api;
        // GET: MUser
        private readonly ApplicationDbContext _db;
        public MUserController(ApplicationDbContext db)
        {
            _db = db;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            this.api = "https://localhost:7186/api/Orders";
        }

        public ActionResult Index()
        {
            IEnumerable<ApplicationUser> usList = _db.Users.ToList();
            IEnumerable<IdentityUserRole<string>> usRoles = _db.UserRoles.ToList();
            IEnumerable<IdentityRole<string>> rolesList = _db.Roles.ToList();
            IEnumerable<ApplicationUser> ownerUsers = from user in usList
                                                      join userRole in usRoles on user.Id equals userRole.UserId
                                                      join role in rolesList on userRole.RoleId equals role.Id
                                                      where role.Name == "Owner"
                                                      select user;

            return View(ownerUsers);    
          
        }
        public ActionResult Customer()
        {
            IEnumerable<ApplicationUser> usList = _db.Users.ToList();
            IEnumerable<IdentityUserRole<string>> usRoles = _db.UserRoles.ToList();
            IEnumerable<IdentityRole<string>> rolesList = _db.Roles.ToList();
            IEnumerable<ApplicationUser> ownerUsers = from user in usList
                                                      join userRole in usRoles on user.Id equals userRole.UserId
                                                      join role in rolesList on userRole.RoleId equals role.Id
                                                      where role.Name == "Customer"
                                                      select user;

            return View("Index",ownerUsers);

        }
        // GET: MUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MUser/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MUser/Edit/5
        public IActionResult Edit(string id)
        {
            ApplicationUser obj = _db.Users.Find(id);
            if (obj == null)
            {
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // POST: MUser/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, ApplicationUser obj)
        {
            if (ModelState.IsValid)
            {
                obj.Id = id;
                var result = _db.Users.SingleOrDefault(b => b.Id == id);
                if (result != null)
                    result.FullName = obj.FullName;
                    result.Address = obj.Address;
                    result.DofB =obj.DofB;
                    result.Gender = obj.Gender;
                    
                {
                    result.FullName = obj.FullName;
                    _db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: MUser/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var c = _db.Users.Find(id);

            if (c == null)
            {
                return NotFound();

            }
            HttpResponseMessage response = await client.GetAsync(api);
            string data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Order> list = JsonSerializer.Deserialize<List<Order>>(data, options);
            list = list.Where(o => o.cus_id == id).ToList();
            foreach(var o in list)
            {
                HttpResponseMessage respon1 = await client.DeleteAsync(api + "/" + o.ID);

            }
            var message = await MailUtils.SendMail("thongnqgcc200003@fpt.edu.vn", c.Email, "FPT Book: Your account is deleted", "Your account has been suspended for policy violation", "thongnqgcc200003@fpt.edu.vn", "Tkcuatui1107.");
            _db.Users.Remove(c);
            _db.SaveChanges();
            return View("Index");
        }
                
        // POST: MUser/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
