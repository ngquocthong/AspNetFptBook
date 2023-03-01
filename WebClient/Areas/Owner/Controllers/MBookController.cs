using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
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
            //var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            //client.DefaultRequestHeaders.Accept.Add(contentType);
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
        public async Task<ActionResult> Create()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.cate_id = new SelectList(await GetCategories(), "ID", "cate_name");
            ViewData["userID"] = userID;
            return View("Create");
        }

        private async Task<List<Category>> GetCategories()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:7186/api/Category");
                string data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                List<Category> list = JsonSerializer.Deserialize<List<Category>>(data, options);
                return list;
            }
            catch (JsonException ex)
            {
                return new List<Category>();
            }
        }

       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Book book)
        {
            try
            {
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                book.owner_id = userID;
                book.book_img = "";

                    string data = JsonSerializer.Serialize(book);
                    var content = new StringContent(data, System.Text.Encoding.UTF8, "multipart/form-data");
                    HttpResponseMessage respon = await client.PostAsync(api, content);
                    if (respon.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        return RedirectToAction("Index");
                    }
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
*/
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
