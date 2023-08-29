using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_data_access;
using Shop_data_access.Data.Configurations;
using Shop_data_access.Entities;

namespace Shop_data_access.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Worker> Workers { get; set; } = null!;
        public DbSet<Shop> Shops { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        //public DbSet<ShopsProducts> ShopsProducts { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                       : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ShopsConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());
            modelBuilder.ApplyConfiguration(new ShopsProductsConfiguration());
            DbInitializer.SeedData(modelBuilder);
        }
    }
}
