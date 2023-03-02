using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Text.Json;
using WebClient.Areas.SendMail.Models;

namespace WebClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminPolicy")]
    public class MCategoryController : Controller
    {
        private readonly HttpClient client = null;
        private string api;
        public MCategoryController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            this.api = "https://localhost:7186/api/Category";
        }
       
        // GET: ManageCategory
        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult> Index()
        {
            try
            {
            HttpResponseMessage respon = await client.GetAsync(api);
            string data = await respon.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Category> list = JsonSerializer.Deserialize<List<Category>>(data, options);
            return View(list);
            }
            catch (JsonException ex)
            {
                return View(new List<Category>());
            }
        }

        // GET: ManageCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManageCategory/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ManageCategory/Create
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

        // GET: ManageCategory/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage respon = await client.GetAsync(api + "/" + id);
            if (respon.IsSuccessStatusCode)
            {
                var data = respon.Content.ReadAsStringAsync().Result;
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var obj = JsonSerializer.Deserialize<Category>(data, options);
                
                return View(obj);
            }
            return NotFound();
        }

        // POST: ManageCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category obj)
        {
            obj.ID = id;
            obj.accept = true;
			string data = JsonSerializer.Serialize<Category>(obj);
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage respon = await client.PutAsync(api + "/" + id, content);
            if (respon.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        // GET: ManageCategory/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
			HttpResponseMessage respon = await client.GetAsync(api + "/" + id);
			string data = await respon.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			Category c = JsonSerializer.Deserialize<Category>(data, options);
			var message = await MailUtils.SendMail("thongnqgcc200003@fpt.edu.vn", c.email_request, "FPT Book: Denying Category", $"After consideration, we sorry to say that, {c.cate_name} has been denied by Admin. Sorry!", "thongnqgcc200003@fpt.edu.vn", "Tkcuatui1107.");
			string catejson = JsonSerializer.Serialize<Category>(c);
			HttpResponseMessage respon1 = await client.DeleteAsync(api + "/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
       /* [ValidateAntiForgeryToken]*/
        public async Task<ActionResult> Accept(int id)
        {
            HttpResponseMessage respon = await client.GetAsync(api);
            string data = await respon.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            List<Category> list = JsonSerializer.Deserialize<List<Category>>(data, options);
            var c = list.Where(cate=> cate.ID == id).FirstOrDefault();
          
            c.accept = true;
			var message = await MailUtils.SendMail("thongnqgcc200003@fpt.edu.vn", c.email_request, "FPT Book: Accepting Category", $"{c.cate_name} has been added to the system. Thank you for your submission!", "thongnqgcc200003@fpt.edu.vn", "Tkcuatui1107.");
			string catejson = JsonSerializer.Serialize<Category>(c);
            var content = new StringContent(catejson, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(api + "/" + id, content);
            if (respon.IsSuccessStatusCode)
            {
             return RedirectToAction("Index");
            }
            return View("Index");
        }

        
    }
}
