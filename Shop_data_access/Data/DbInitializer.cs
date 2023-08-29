using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_data_access.Data.Configurations;
using Shop_data_access.Entities;

namespace Shop_data_access.Data
{
    public static class DbInitializer
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(new Position[]
            {
                new Position() { Id = 1, Name="Manager"},
                new Position() { Id = 2, Name="Seller"},
                new Position() { Id = 3, Name="Cleaner"},
            });
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category() { Id = 1, Name="Food"},
                new Category() { Id = 2, Name="Garden"},
                new Category() { Id = 3, Name="Car ware"}
            });
            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country() { Id = 1, Name = "Ukraine"},
                new Country() { Id = 2, Name = "Italy" },
                new Country() { Id = 3, Name = "Great Britain" },
                new Country() { Id = 4, Name = "France" },
                new Country() { Id = 5, Name = "USA" }
            });
            modelBuilder.Entity<City>().HasData(new City[]
            {
                new City() { Id = 1, Name="Kyiv", CountryId=1 },
                new City() { Id = 2, Name="Rome", CountryId=2 },
                new City() { Id = 3, Name="London", CountryId=3 },
                new City() { Id = 4, Name="Parice", CountryId=4 },
                new City() { Id = 5, Name="Washington", CountryId=5 },
            });
            Shop shop1 = new Shop() { Id = 1, Name = "Shop1", Address = "Soborna 12", ParkingArea = 25, CityId = 1 };
            Shop shop2 = new Shop() { Id = 2, Name = "Shop2", Address = "Kovalyova 21", ParkingArea = 20, CityId = 2 };
            Shop shop3 = new Shop() { Id = 3, Name = "Shop3", Address = "Franka 45", CityId = 3 };
            Shop shop4 = new Shop() { Id = 4, Name = "Shop4", Address = "Shevchenka 61", CityId = 4 };
            Shop shop5 = new Shop() { Id = 5, Name = "Shop5", Address = "Bila 58", ParkingArea = 30, CityId = 5 };
            Shop shop6 = new Shop() { Id = 6, Name = "Shop6", Address = "Nebesna 87", ParkingArea = 15, CityId = 5 };

            modelBuilder.Entity<Shop>().HasData(new Shop[]
            {
                shop1, shop2, shop3, shop4, shop5, shop6
            });

            Product prod1 = new Product() { Id = 1, Name = "Apple", CategoryId = 1, Discount = 5, Price = 8, Quantity = 1500, IsInStock = false };
            Product prod2 = new Product() { Id = 2, Name = "Laptop", CategoryId = 2, Discount = 0, Price = 1500, Quantity = 9, IsInStock = false };
            Product prod3 = new Product() { Id = 3, Name = "Scisors", CategoryId = 3, Discount = 2.3f, Price = 32, Quantity = 40, IsInStock = false };
            Product prod4 = new Product() { Id = 4, Name = "Phone case", CategoryId = 2, Discount = 0, Price = 40, Quantity = 200, IsInStock = true };
            Product prod5 = new Product() { Id = 5, Name = "Joice", CategoryId = 1, Discount = 5, Price = 15, Quantity = 150, IsInStock = false };

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                prod1, prod2, prod3, prod4, prod5
            });
            modelBuilder.Entity<Worker>().HasData(new Worker[]
            {
                new Worker() { Id = 1, Name="Jo", Surname="Biden", Email="jobiden@gmail.com", PhoneNumber="0234234", Salary=2344, PositionId=1, ShopId=1},
                new Worker() { Id = 2, Name="Den", Surname="Green", Email="dengree@gmail.com", PhoneNumber="3453463", Salary=2363, PositionId=1, ShopId=2},
                new Worker() { Id = 3, Name="Sam", Surname="Black", Email="samblack@gmail.com", PhoneNumber="34637457", Salary=1558, PositionId=1, ShopId=3},
                new Worker() { Id = 4, Name="Max", Surname="Red", Email="maxred@gmail.com", PhoneNumber="234353", Salary=1954, PositionId=3, ShopId=2},
                new Worker() { Id = 5, Name="Liam", Surname="White", Email="liamwhite@gmail.com", PhoneNumber="34534", Salary=3163, PositionId=2, ShopId=1},
            });

        }
    }
}
