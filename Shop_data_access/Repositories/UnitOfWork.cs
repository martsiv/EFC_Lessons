using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop_data_access.Data;
using Shop_data_access.Entities;

namespace Shop_data_access.Repositories
{
    public interface IUoW
    {
        IRepository<Category> CategoryRepo { get; }
        IRepository<City> CityRepo { get; }
        IRepository<Country> CountryRepo { get; }
        IRepository<Position> PositionRepo { get; }
        IRepository<Product> ProductRepo { get; }
        IRepository<Shop> ShopRepo { get; }
        IRepository<ShopsProducts> ShopsProductsRepo { get; }
        IRepository<Worker> WorkerRepo { get; }
        void Save();
    }

    public class UnitOfWork : IUoW, IDisposable
    {
        private static ApplicationContext context = null;
        private IRepository<Category>? categoryRepo = null;
        private IRepository<City?> cityRepo = null;
        private IRepository<Country?> countryRepo = null;
        private IRepository<Position?> positionRepo = null;
        private IRepository<Product?> productRepo = null;
        private IRepository<Shop?> shopRepo = null;
        private IRepository<ShopsProducts?> shopsProductsRepo = null;
        private IRepository<Worker?> workerRepo = null;
        public UnitOfWork(DbContextOptions<ApplicationContext> option)
        {
            ApplicationContext context = new ApplicationContext(option);
        }
        public IRepository<Category> CategoryRepo
        {
            get
            {
                if (this.categoryRepo == null)
                {
                    this.categoryRepo = new Repository<Category>(context);
                }
                return categoryRepo;
            }
        }
        public IRepository<City> CityRepo
        {
            get
            {
                if (this.cityRepo == null)
                {
                    this.cityRepo = new Repository<City>(context);
                }
                return cityRepo;
            }
        }

        public IRepository<Country> CountryRepo
        {
            get
            {
                if (this.countryRepo == null)
                {
                    this.countryRepo = new Repository<Country>(context);
                }
                return countryRepo;
            }
        }
        public IRepository<Position> PositionRepo
        {
            get
            {
                if (this.positionRepo == null)
                {
                    this.positionRepo = new Repository<Position>(context);
                }
                return positionRepo;
            }
        }
        public IRepository<Product> ProductRepo
        {
            get
            {
                if (this.productRepo == null)
                {
                    this.productRepo = new Repository<Product>(context);
                }
                return productRepo;
            }
        }
        public IRepository<Shop> ShopRepo
        {
            get
            {
                if (this.shopRepo == null)
                {
                    this.shopRepo = new Repository<Shop>(context);
                }
                return shopRepo;
            }
        }
        public IRepository<ShopsProducts> ShopsProductsRepo
        {
            get
            {
                if (this.shopsProductsRepo == null)
                {
                    this.shopsProductsRepo = new Repository<ShopsProducts>(context);
                }
                return shopsProductsRepo;
            }
        }
        public IRepository<Worker> WorkerRepo
        {
            get
            {
                if (this.workerRepo == null)
                {
                    this.workerRepo = new Repository<Worker>(context);
                }
                return workerRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
