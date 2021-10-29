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
    public class FluentBookAuthorCfg : IEntityTypeConfiguration<Fluent_BookAuthor>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthor> builder)
        {
            builder.HasKey(ba => new { ba.Author_Id, ba.Book_Id });
            builder.HasOne(ba => ba.Fluent_Book).WithMany(ba => ba.Fluent_BookAuthors).HasForeignKey(ba => ba.Book_Id);
            builder.HasOne(ba => ba.Fluent_Author).WithMany(ba => ba.Fluent_BookAuthors).HasForeignKey(ba => ba.Author_Id);
        }
    }
}
