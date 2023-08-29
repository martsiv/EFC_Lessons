using Shop_data_access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_data_access.Entities
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public List<Shop> Shops { get; set; } = new();
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
