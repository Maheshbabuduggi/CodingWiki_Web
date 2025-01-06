using CodingWiki_DataAccess;
using CodingWiki_Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class PublisherController : Controller
    {
        private ApplicationDBContext _db;
        public PublisherController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var obj = _db.Publisher.ToList();

            return View(obj);
        }

        public IActionResult Upsert(int? id)
        {
            Publisher obj = new();
            if (id == null || id == 0)
            {

                return View(obj);
            }
            obj = _db.Publisher.FirstOrDefault(u => u.Publisher_Id == id);
            if (obj == null) { return NotFound(); }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(Publisher obj)
        {
            if (ModelState.IsValid)
            {
                if (obj == null)
                {

                    _db.Publisher.Add(obj);

                }
                else
                {

                    _db.Publisher.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);

        }

        public IActionResult Delete(int id)
        {
            Publisher obj = new();
            obj = _db.Publisher.FirstOrDefault(u => u.Publisher_Id == id);
            if (obj == null) { return NotFound(); }
            _db.Publisher.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
