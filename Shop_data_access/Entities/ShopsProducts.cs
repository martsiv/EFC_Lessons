using Shop_data_access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_data_access.Entities
{
    public class ShopsProducts : IEntity
    {
        public int ShopId { get; set; }
        public Shop? Shop { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
