using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Intro_to_ef
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public int CountListening { get; set; }
        public string? Text { get; set; }
        public ICollection<Playlist> Playlists { get; set; } = new HashSet<Playlist>();
        public RateOfTrack? RateOfTrack { get; set; }
        public override string ToString()
        {
            return $"{Name}. " +
                $"Duration: {new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Duration.TotalSeconds).ToLongTimeString()}. " +
                $"Count of listening: {CountListening}. " +
                $"Text: {Text}. " +
                $"Album: {Album?.Name ?? "None"}";
        } 
    }
}
