using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEFProject_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEFProject_DataAccess.FluentConfig
{
  public  class FluentBookCfg : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> builder)
        {
            builder.HasKey(b => b.Book_Id);
            builder.Property(b => b.ISBN).IsRequired().HasMaxLength(15);
            builder.Property(b => b.Price).IsRequired();
            builder.Property(b => b.Title).IsRequired();
            builder.HasOne(b => b.Fluent_BookDetail).WithOne(b => b.Fluent_Book).HasForeignKey<Fluent_Book>(b => b.BookDetail_Id);
            builder.HasOne(b => b.Fluent_Publisher).WithMany(b => b.Fluent_Books).HasForeignKey(b => b.Publisher_Id);
        }
    }
}
