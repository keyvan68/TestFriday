using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DB.SqlServer.EF.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasData(
                    new Product { Id = 1, Title = "Product Title1", Price = 10000, Description = "Product Description1" },
                    new Product { Id = 2, Title = "Product Title2", Price = 10000, Description = "Product Description2" },
                    new Product { Id = 3, Title = "Product Title3", Price = 10000, Description = "Product Description3" }
                            );
            });
        }


    }
}
