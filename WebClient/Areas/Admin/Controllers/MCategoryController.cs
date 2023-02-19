using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class MCategoryController : Controller
    {
        // GET: ManageCategory
        [HttpGet]
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManageCategory/Edit/5
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

        // GET: ManageCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManageCategory/Delete/5
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
