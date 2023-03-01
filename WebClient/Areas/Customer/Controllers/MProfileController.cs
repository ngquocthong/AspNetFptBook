using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebClient.Data;

namespace WebClient.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class MProfileController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MProfileController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            
            return View();

        }
        // GET: MUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MUser/Create
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

        // GET: MUser/Edit/5
        public IActionResult Edit(string id)
        {
            ApplicationUser obj = _db.Users.Find(id);
            if (obj == null)
            {
                return RedirectToAction("Edit");
            }
            return View(obj);
        }

        // POST: MUser/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, ApplicationUser obj)
        {
            if (ModelState.IsValid)
            {
                obj.Id = id;
                var result = _db.Users.SingleOrDefault(b => b.Id == id);
                if (result != null)
                    result.FullName = obj.FullName;
                result.Address = obj.Address;
                result.DofB = obj.DofB;
                result.Gender = obj.Gender;

                {
                    result.FullName = obj.FullName;
                    _db.SaveChanges();
                }
                TempData["Message"] = "Update Success";
                return RedirectToAction("Edit");
            }
            return View(obj);
        }

        // GET: MUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MUser/Delete/5
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
