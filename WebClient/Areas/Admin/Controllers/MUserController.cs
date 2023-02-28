using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using WebClient.Data;
using ApplicationDbContext = WebClient.Data.ApplicationDbContext;

namespace WebClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MUserController : Controller
    {
        // GET: MUser
        private readonly ApplicationDbContext _db;
        public MUserController(ApplicationDbContext db)
        {
            _db = db;
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
        public ActionResult Delete(int id)
        {
            return View();
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
