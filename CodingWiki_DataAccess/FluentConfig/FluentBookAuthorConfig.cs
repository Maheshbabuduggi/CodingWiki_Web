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
    public class FluentBookAuthorConfig:IEntityTypeConfiguration<Fluent_Author>
    {
        public void Configure(EntityTypeBuilder<Fluent_Author> modelBuilder)
        {
            modelBuilder.ToTable("Fleunt_Authors");
            modelBuilder.HasKey(k => k.Author_Id);
            modelBuilder.Property(p => p.FirstName).IsRequired();
            modelBuilder.Property(p => p.FirstName).HasMaxLength(50);
            modelBuilder.Ignore(i => i.FullName);
        }   
    }
}
