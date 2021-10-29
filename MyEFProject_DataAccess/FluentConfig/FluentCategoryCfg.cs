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
    public class FluentCategoryCfg : IEntityTypeConfiguration<Fluent_Category>
    {
        public void Configure(EntityTypeBuilder<Fluent_Category> builder)
        {
            builder.HasKey(b => b.Id);
            builder.ToTable("tbl_CategoryFluent");
            builder.Property(b => b.Name).HasColumnName("CategoryName");
        }
    }
}
