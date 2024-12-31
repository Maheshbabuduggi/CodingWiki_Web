using Microsoft.EntityFrameworkCore;
using CodingWiki_Models.Models;

namespace CodingWiki_DataAccess
{
    public class ApplicationDBContext:DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Genre> Genre { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MAHESH;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            var bookList = new List<Book> { 
            
                new Book{BookId=1,Title="MahaBharatha",ISBN="127382",Price=123.10m},
                new Book{BookId=2,Title="RamaYana",ISBN="127382",Price=1229.3m},
                new Book{BookId=3,Title="Spider Fair Tales",ISBN="125",Price=875.3m}
            
            };
            modelBuilder.Entity<Book>().HasData(bookList);

        }
    }
}
