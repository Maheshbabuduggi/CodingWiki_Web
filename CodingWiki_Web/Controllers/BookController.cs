using CodingWiki_DataAccess;
using CodingWiki_Models.Models;
using CodingWiki_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_Web.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDBContext _db;
        public BookController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Book> objList = _db.Book.Include(u => u.Publisher)
                .Include(u => u.AuthorMap).ThenInclude(u => u.Author).ToList();

            //var obj = _db.Book;
            return View(objList);

        }

        public IActionResult Upsert(int? id)
        {
            BookVM obj = new();
            obj.Publishers = _db.Publisher.Select(i => new SelectListItem{
                Text=i.Name,
                Value=i.Publisher_Id.ToString()
            });
            if (id == null || id == 0)
            {

                return View(obj);
            }
            obj.Book = _db.Book.FirstOrDefault(u => u.BookId == id);
            if (obj == null) { return NotFound(); }

            return View(obj);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Upsert(BookVM obj)
        {
            
                if (obj == null)
                {

                    await _db.Book.AddAsync(obj.Book);

                }
                else
                {

                    _db.Book.Update(obj.Book);
                }
               await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

        }
    }
}
