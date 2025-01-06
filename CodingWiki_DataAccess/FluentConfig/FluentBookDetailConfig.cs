using CodingWiki_Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentBookDetailConfig:IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            
            modelBuilder.ToTable("Fluent_BookDetails");
            modelBuilder.HasKey(p => p.BookDetail_Id);
            modelBuilder.Property(p => p.NumberOfChapters).IsRequired();
            modelBuilder.Property(p => p.NumberOfChapters).HasColumnName("NoOfPages");
            modelBuilder.HasOne(b => b.book).WithOne(b => b.BookDetail).HasForeignKey<Fluent_BookDetail>(u => u.Book_Id);

        }
    }
}
