using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class RequestCategory : Controller
    {
        // GET: RequestCategory
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
