using CodingWiki_DataAccess;
using CodingWiki_Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var obj =_db.Category.ToList();
            
            return View(obj);
        }

        public IActionResult Upsert(int? id)
        {
            Category obj = new();
            if (id == null || id == 0) {

                return View(obj);
            }
            obj = _db.Category.FirstOrDefault(u => u.Category_Id==id);
            if (obj == null) { return NotFound(); }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(Category obj) {
            if (ModelState.IsValid)
            {
                if (obj == null)
                {

                    _db.Category.Add(obj);

                }
                else
                {

                    _db.Category.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        
        }

        public IActionResult Delete(int id)
        {
            Category obj = new();
            obj= _db.Category.FirstOrDefault(u => u.Category_Id==id);
            if (obj == null) { return NotFound(); }
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple2()
        {
            List<Category> list = new();
            for(int i = 1; i <= 2; ++i)
            {
                list.Add(new Category { CategoryName=Guid.NewGuid().ToString() });
            }
            _db.Category.AddRange(list);
            _db.SaveChanges();
            //return View(list);
           return RedirectToAction(nameof(Index));

        }
        public IActionResult CreateMultiple5()
        {
            List<Category> list = new();
            for (int i = 1; i <= 5; ++i)
            {
                list.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
            }
            _db.Category.AddRange(list);
            _db.SaveChanges();
            //return View(list);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult RemoveMultiple2()
        {
            List<Category> list = _db.Category.OrderByDescending(u=>u.Category_Id).Take(2).ToList();
            
            _db.Category.RemoveRange(list);
            _db.SaveChanges();
            //return View(list);
            return RedirectToAction(nameof(Index));

        }
        public IActionResult RemoveMultiple5()
        {
            List<Category> list = _db.Category.OrderByDescending(u => u.Category_Id).Take(5).ToList();

            _db.Category.RemoveRange(list);
            _db.SaveChanges();
            //return View(list);
            return RedirectToAction(nameof(Index));

        }

    }
}
