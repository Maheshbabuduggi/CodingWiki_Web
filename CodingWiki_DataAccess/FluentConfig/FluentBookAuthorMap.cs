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
    public class FluentBookAuthorMapConfig:IEntityTypeConfiguration<Fluent_BookAuthorMap>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthorMap> modelBuilder)
        {
            modelBuilder.HasKey(k => new { k.Author_Id, k.Book_Id });
            modelBuilder.HasOne(b => b.Book).WithMany(a => a.fluent_bookAuthorMap).HasForeignKey(k => k.Book_Id);
            modelBuilder.HasOne(a => a.Author).WithMany(b => b.fluent_bookAuthorMap).HasForeignKey(k => k.Author_Id);


        }
    }
}
