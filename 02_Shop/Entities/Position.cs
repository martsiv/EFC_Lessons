using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Shop
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Worker> Workers { get; set; } = new();
    }
}
