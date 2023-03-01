using System.Data;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebClient.Data;
using ApplicationDbContext = WebClient.Data.ApplicationDbContext;

namespace WebClient.Areas.Owner.Controllers
{
    [Area("Owner")]
    [Authorize(Roles = "Owner")]
    public class MOrderController : Controller
    {
		private readonly ApplicationDbContext _db;
		
			
		// GET: BookController
		private readonly HttpClient client = null;
        private string api;
        public MOrderController(ApplicationDbContext db)
        {
            _db = db;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            this.api = "https://localhost:7186/api/Orders";

        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<ApplicationUser> usList = _db.Users.ToList();


            ViewBag.Customer = usList;

			HttpResponseMessage response = await client.GetAsync(api);
            string data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Order> list = JsonSerializer.Deserialize<List<Order>>(data, options);
            
            return View(list);
            
        }

        // GET: MOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MOrder/Create
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

        // GET: MOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MOrder/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: MOrder/Delete/5
        /*public ActionResult Delete(int id)
        {
            List<Order> orders= new List<Order>();
            var order = orders.Find(o => o.ID == id);
            orders.Remove(order);
            _db.SaveChanges();
            return View("Index");
        }*/

        // POST: MOrder/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
           

                HttpResponseMessage respon = await client.DeleteAsync(api + "/" + id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
