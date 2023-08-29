using Shop_data_access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_data_access.Entities
{
    public class Shop : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public City? City { get; set; }
        public int? ParkingArea { get; set; }
        public List<Product> Products { get; set; } = new();
        public List<ShopsProducts> ShopsProducts { get; set; } = new();
        public List<Worker> Workers { get; set; } = new();
    }
}
