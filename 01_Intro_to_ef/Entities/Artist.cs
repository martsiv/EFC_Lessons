using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Intro_to_ef
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CountrieId { get; set; }
        public Country Countrie { get; set; }
        public ICollection<Album> Albums { get; set; } = new HashSet<Album>();
        public override string ToString()
        {
            return $"{Name} {Surname}. Countrie - {Countrie?.Name ?? "None"}";
        }
    }
}
