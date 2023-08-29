using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Shop.Entities
{
    public class ShopsProducts
    {
        public int ShopId { get; set; }
        public Shop? Shop { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
