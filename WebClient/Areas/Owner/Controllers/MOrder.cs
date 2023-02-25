using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class MOrder : Controller
    {
        // GET: MOrder
        public ActionResult Index()
        {
            return View();
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
