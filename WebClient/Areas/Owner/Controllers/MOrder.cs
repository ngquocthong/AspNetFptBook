using System.Data;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Areas.Owner.Controllers
{
    [Area("Owner")]
    [Authorize(Roles = "Owner")]
    public class MOrder : Controller
    {
        // GET: BookController
        private readonly HttpClient client = null;
        private string api;
        public MOrder()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            this.api = "https://localhost:7186/api/Orders";

        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MOrder/Delete/5
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
