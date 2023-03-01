using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Net.Http.Headers;

namespace WebClient.Areas.Owner.Controllers
{

    [Area("Owner")]
    public class RequestCategoryController : Controller
    {
        private readonly HttpClient client = null;
        private string api;
        // GET: RequestCategory
        public RequestCategoryController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            this.api = "https://localhost:7186/api/Category";
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: RequestCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RequestCategory/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: RequestCategory/Create
        [HttpPost]
       /* [ValidateAntiForgeryToken]*/
        public async Task<ActionResult> Create(Category cate)
        {

            if (ModelState.IsValid)
            {
                TempData["Message"] = "Request Success! Please waiting for Admin's response";
                string data = JsonSerializer.Serialize(cate);
                var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage respon = await client.PostAsync(api, content);
                if (respon.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("Index");
                }
            } else ViewBag.success =false;
            return View();
           /* try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }*/
        }

        // GET: RequestCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RequestCategory/Edit/5
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

        // GET: RequestCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RequestCategory/Delete/5
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
