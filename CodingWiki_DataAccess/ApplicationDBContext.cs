using Microsoft.EntityFrameworkCore;
using CodingWiki_Models.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CodingWiki_DataAccess.FluentConfig;

namespace CodingWiki_DataAccess
{
    public class ApplicationDBContext:DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<BookDetail> BookDetail { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        public DbSet<BookAuthorMap> BookAuthorMap { get; set; }

        public DbSet<Fluent_BookDetail> FluentBookDetail { get; set; }
        public DbSet<Fluent_Book> fluent_Books { get; set; }

        public DbSet<Fluent_Author> FluentAuthor { get; set; }

        public DbSet<Fluent_Publisher> FluentPublisher { get; set; }

        public DbSet<Fluent_BookAuthorMap> fluent_BookAuthorMaps { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseSqlServer("Server=MAHESH;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
            modelBuilder.ApplyConfiguration(new FluentBookPublisherConfig());
            //modelBuilder.Entity<BookDetail>().HasOne(b => b.book).WithOne(b => b.BookDetail).HasForeignKey<BookDetail>(k => k.Book_Id);
            modelBuilder.Entity<BookAuthorMap>().HasKey(k => new { k.Author_Id, k.Book_Id });
            modelBuilder.Entity<Book>().HasOne(p=>p.Publisher).WithMany(b=>b.Books).HasForeignKey(k=>k.Publisher_Id);
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            var bookList = new List<Book> { 
            
                new Book{BookId=1,Title="MahaBharatha",ISBN="127382",Price=123.10m,Publisher_Id=1},
                new Book{BookId=2,Title="RamaYana",ISBN="127382",Price=1229.3m,Publisher_Id=2},
                new Book{BookId=3,Title="Spider Fair Tales",ISBN="125",Price=875.3m,Publisher_Id=1}
            
            };
            modelBuilder.Entity<Book>().HasData(bookList);
            var publishers = new List<Publisher>
                                        {
                                            new Publisher
                                            {
                                                Publisher_Id = 1,
                                                Name = "Penguin Random House",
                                                Location = "New York, USA"
                                            },
                                            new Publisher
                                            {
                                                Publisher_Id = 2,
                                                Name = "HarperCollins",
                                                Location = "London, UK"
                                            },
                                            new Publisher
                                            {
                                                Publisher_Id = 3,
                                                Name = "Macmillan Publishers",
                                                Location = "New York, USA"
                                            },
                                            new Publisher
                                            {
                                                Publisher_Id = 4,
                                                Name = "Simon & Schuster",
                                                Location = "New York, USA"
                                            },
                                            new Publisher
                                            {
                                                Publisher_Id = 5,
                                                Name = "Hachette Livre",
                                                Location = "Paris, France"
                                            }
                                        };

            modelBuilder.Entity<Category>().Property(c => c.Category_Id).HasColumnName("Category_Id");
            modelBuilder.Entity<Category>().Property(c => c.CategoryName).HasColumnName("CategoryName");

            var data = new Category { Category_Id=10,CategoryName = "Physics" };
            modelBuilder.Entity<Category>().HasData(data);
            modelBuilder.Entity<Publisher>().HasData(publishers);


        }
    }
}
