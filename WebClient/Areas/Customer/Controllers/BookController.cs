using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace WebClient.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class BookController : Controller
    {
        // GET: BookController
        private readonly HttpClient client = null;
        private string api;
        public BookController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            this.api = "https://localhost:7186/api/Book";

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var userRole = User.FindFirstValue(ClaimTypes.Role);

                if (userRole == "Owner")
                {
                    return Redirect("Owner/MBook");
                }
                else if (userRole == "Admin")
                {
                    return Redirect("Admin/MCategory");
                }
                else
                {
                    HttpResponseMessage response = await client.GetAsync(api);
                    string data = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    List<Book> list = JsonSerializer.Deserialize<List<Book>>(data, options);
                    return View(list);
                }
            }

            catch (JsonException ex)
            {
                return View(new List<Book>());
            }
		}

        // GET: BookController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync(api + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var obj = JsonSerializer.Deserialize<Book>(data, options);
                return View(obj);
            }
            return Ok();
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
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
        public  async Task<ActionResult> Search(string word)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(api);
                if(response.IsSuccessStatusCode) { 
			    var data = response.Content.ReadAsStringAsync().Result;
			    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				List<Book> obj = JsonSerializer.Deserialize<List<Book>>(data, options);
				List<Book> filteredbook = obj.Where(b => b.book_name.ToLower().Contains(word.Trim().ToLower())).ToList();
				return View("Index", filteredbook);
                }
			}
			catch (JsonException ex)
            {
                return View();
            } 
            return Ok();
        }
    }
}
