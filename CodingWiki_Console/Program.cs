using CodingWiki_DataAccess;
using CodingWiki_Models.Models;
using Microsoft.EntityFrameworkCore;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


////UpdateBook();

//void UpdateBook()
//{
//    using var context = new ApplicationDBContext();
//    var b = context.Book.Where(p => p.publisher_Id == 1).ToList();
//    //context.Book.Remove(book);
//    // var b = book.Remove;
//    b.ForEach(b =>
//    {
//        Console.WriteLine(b.Title);
//    });
//    context.SaveChanges();
//}

////GetBook();

//async void GetBook()
//{
//    using var context = new ApplicationDBContext();

//    var b = await context.Book.Skip(0).Take(2).ToListAsync();
//    //Console.WriteLine(b.Title+"\t"+b.Price+"\t"+b.ISBN);
//    b.ForEach(p =>
//    {
//        Console.WriteLine(p.Title + "\t" + p.publisher_Id);
//    });
//}
////AddBooks();
//async void AddBooks()
//{
//    Book book = new Book
//    {
//        Title = "New England Tales",
//        ISBN = "799-57",
//        Price = 1203,
//        publisher_Id = 5
//    };

//    using var context = new ApplicationDBContext();
//    await context.Book.AddAsync(book);
//    await context.SaveChangesAsync();

//}

////GetAllBooks();

//void GetAllBooks()
//{
//    var context = new ApplicationDBContext();
//    var books = context.Book.ToList();
//    books.ForEach(book =>
//    {
//        Console.WriteLine(book.Title + "\t" + book.ISBN);
//    });
//}




