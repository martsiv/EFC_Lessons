using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Intro_to_ef
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PathToImage { get; set; }
        public int Year { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
        public RateOfAlbum? RateOfAlbum { get; set; }
    }
}
