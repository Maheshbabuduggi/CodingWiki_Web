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
            List<Book> objList= _db.Book.Include(u=>u.Publisher).ToList();

            //foreach (var obj in objList)
            //{
            //    more efficient
            //    _db.Entry(obj).Reference(u => u.Publisher).Load();

            //    least efficient
            //    obj.Publisher = _db.Publisher.Find(obj.Publisher_Id);
            //}
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



        public IActionResult Details(int? id)
        {
            BookDetail obj = new();
           
            if (id == null || id == 0)
            {

                return NotFound();
            }
            //obj.book=_db.Book.FirstOrDefault(u=>u.BookId == id);
            obj = _db.BookDetail.Include(b=>b.book).FirstOrDefault(u => u.Book_Id == id);
            if (obj == null) {
                return NotFound();
            }
            return View(obj);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Details(BookDetail obj)
        {

            if (obj.BookDetail_Id==0)
            {

                await _db.BookDetail.AddAsync(obj);

            }
            else
            {

                _db.BookDetail.Update(obj);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            Book obj = new();
            obj = _db.Book.FirstOrDefault(u => u.BookId == id);
            if (obj == null) { return NotFound(); }
            _db.Book.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult PlayGround()
        {
            IEnumerable<Book> books = _db.Book;
            var filter1 = books.Where(p => p.Price > 10);

            IQueryable<Book> book=_db.Book;
            var filter2=book.Where(p => p.Price > 10);
           return RedirectToAction(nameof(Index));
        }
    }
}
