using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Intro_to_ef
{
    public class RateOfTrack
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        [Required]
        public int? TrackId { get; set; }
        [Required]
        public Track? Track { get; set; }
    }
}
