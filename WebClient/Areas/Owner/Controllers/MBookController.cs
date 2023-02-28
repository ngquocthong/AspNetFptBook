using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace WebClient.Areas.Customer.Controllers
{
    [Area("Owner")]
    [Authorize(Roles = "Owner")]
    public class MBookController : Controller
    {
        // GET: BookController
        private readonly HttpClient client = null;
        private string api;
        public MBookController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            this.api = "https://localhost:7186/api/Book";
        }

        public async Task<ActionResult> Index()
        {

            try
            {
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                HttpResponseMessage response = await client.GetAsync(api);
                string data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                List<Book> list = JsonSerializer.Deserialize<List<Book>>(data, options);
                list = list.Where(b => b.owner_id == userID).ToList();
                return View(list);
            }
            catch (JsonException ex)
            {
                return View(new List<Book>());
            }
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController/Create
        [HttpGet]
        public ActionResult Create()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["userID"] = userID;
            return View("Create");
        }

        // POST: BookController/Create
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

        // GET: BookController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync(api + "/" + id);

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var obj = JsonSerializer.Deserialize<Book>(data, options);               
                return View(obj);
            }
            return NotFound();
        }

        // POST: BookController/Edit/5
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

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: BookController/Delete/5
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
