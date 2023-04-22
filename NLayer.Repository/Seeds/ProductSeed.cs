using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product()
            {
                Id = 1,
                CategoryId = 1,
                Name = "Kitap 1",
                Stock = 20,
                Price = 100,
                CreatedDate = DateTime.Now

            },
            new Product()
            {

                Id = 2,
                CategoryId = 2,
                Name = "Kalem 1",
                Stock = 10,
                Price = 50,
                CreatedDate = DateTime.Now
            },
            new Product()
            {

                Id = 3,
                CategoryId = 3,
                Name = "Defter 1",
                Stock = 35,
                Price = 80,
                CreatedDate = DateTime.Now
            },
             new Product()
             {

                 Id = 4,
                 CategoryId = 1,
                 Name = "Kitap 2",
                 Stock = 40,
                 Price = 100,
                 CreatedDate = DateTime.Now
             });
        }
    }
}
