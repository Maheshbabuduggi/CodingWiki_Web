using CodingWiki_Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentBookConfig:IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {

            modelBuilder.HasKey(k => k.BookId);
            modelBuilder.Ignore(i => i.DiscountedPrice);
            modelBuilder.Property(p => p.Price).HasPrecision(10, 5);
            modelBuilder.HasOne(p => p.Publisher).WithMany(b => b.Books).HasForeignKey(k => k.publisher_Id);
        }
    }
}
