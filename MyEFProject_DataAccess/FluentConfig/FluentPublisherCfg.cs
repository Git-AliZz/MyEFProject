using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEFProject_Model.Models;

namespace MyEFProject_DataAccess.FluentConfig
{
    public class FluentPublisherCfg: IEntityTypeConfiguration<Fluent_Publisher>
    {
        public void Configure(EntityTypeBuilder<Fluent_Publisher> builder)
        {
            builder.HasKey(i => i.Publisher_Id);
            builder.Property(i => i.Name).IsRequired();
            builder.Property(i => i.Location).IsRequired();
        }
    }
}
