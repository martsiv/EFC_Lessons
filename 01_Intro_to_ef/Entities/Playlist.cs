﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Intro_to_ef
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PathToImage { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
        public override string ToString()
        {
            return $"{Name} {PathToImage}";
        }
    }
}
