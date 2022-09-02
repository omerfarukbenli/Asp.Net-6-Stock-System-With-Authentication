using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokApp.Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokApp.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ProductName).IsRequired();
            builder.Property(x => x.ProductName).HasColumnName("Name");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.ProductName).HasMaxLength(50);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.HasOne(e => e.Category).WithMany(c => c.Products);
            builder.HasData(
                    new Product { CategoryId = 1, Id = 1, ProductName = "kalem1" },
                    new Product { CategoryId = 3, Id = 2, ProductName = "Kalem2" },
                    new Product { CategoryId = 2, Id = 3, ProductName = "Kalem3" },
                    new Product { CategoryId = 2, Id = 4, ProductName = "Kale4" },
                    new Product { CategoryId = 4, Id = 5, ProductName = "Kalem5" },
                    new Product { CategoryId = 3, Id = 6, ProductName = "Kalem6" },
                    new Product { CategoryId = 4, Id = 7, ProductName = "Kale7" },
                    new Product { CategoryId = 4, Id = 8, ProductName = "Kalem8" },
                    new Product { CategoryId = 5, Id = 9, ProductName = "Kalem9" },
                    new Product { CategoryId = 5, Id = 10, ProductName = "Kalem10" }
                    );
        }
    }
}
