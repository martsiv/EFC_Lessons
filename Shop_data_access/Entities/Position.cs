using Shop_data_access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_data_access.Entities
{
    public class Position : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Worker> Workers { get; set; } = new();
    }
}
