using CodingWiki_DataAccess;
using CodingWiki_Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class AuthorController : Controller
    {
        private ApplicationDBContext _db;
        public AuthorController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var obj = _db.Authors.ToList();

            return View(obj);
        }

        public IActionResult Upsert(int? id)
        {
            Author obj = new();
            if (id == null || id == 0)
            {

                return View(obj);
            }
            obj = _db.Authors.First(u => u.Author_Id == id);
            if (obj == null) { return NotFound(); }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(Author obj)
        {
            if (ModelState.IsValid)
            {
                if (obj == null)
                {

                    _db.Authors.Add(obj);

                }
                else
                {

                    _db.Authors.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);

        }

        public IActionResult Delete(int id)
        {
            Author obj = new();
            obj = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
            if (obj == null) { return NotFound(); }
            _db.Authors.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
