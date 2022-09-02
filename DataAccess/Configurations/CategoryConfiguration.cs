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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CategoryName).IsRequired();
            builder.Property(x => x.CategoryName).HasColumnName("Name");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.CategoryName).HasMaxLength(50);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.HasMany(x => x.Products).WithOne(x => x.Category);
            builder.HasData(
                    new Category { Id = 1, CategoryName = "kalem1" },
                    new Category { Id = 2, CategoryName = "Kalem2" },
                    new Category { Id = 3, CategoryName = "Kalem3" },
                    new Category { Id = 4, CategoryName = "Kale4" },
                    new Category { Id = 5, CategoryName = "Kalem5" },
                    new Category { Id = 6, CategoryName = "Kalem6" },
                    new Category { Id = 7, CategoryName = "Kale7" },
                    new Category { Id = 8, CategoryName = "Kalem8" },
                    new Category { Id = 9, CategoryName = "Kalem9" },
                    new Category { Id = 10, CategoryName = "Kalem10" }
                    );
        }
    }
}
