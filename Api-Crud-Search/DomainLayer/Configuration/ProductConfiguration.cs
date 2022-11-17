using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Count).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasPrecision(12, 10);
            builder.Property(x=>x.SoftDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreateDate).HasDefaultValue(DateTime.UtcNow);

            builder.HasQueryFilter(x => !x.SoftDeleted);
        }
    }
}
