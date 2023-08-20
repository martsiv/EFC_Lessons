using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace _01_Intro_to_ef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("MyDbConnection");

            var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionBuilder.UseSqlServer(connectionString).Options;
            using (ApplicationContext db = new ApplicationContext(options))
            {

                //db.Tracks.AddRange(new Track[]
                //{
                //    new Track() {  Name = "Track05", AlbumId = 3, Duration = new(2000000000)},
                //    new Track() {  Name = "Track06", AlbumId = 3, Duration = new(2040000000)},
                //    new Track() { Name = "Track07", AlbumId = 3, Duration = new(2100000000)},
                //    new Track() { Name = "Track08", AlbumId = 3, Duration = new(2050000000)},

                //});
                //db.SaveChanges();
            }
            MusicCollectionControl mc = new();
            mc.Run();
        }
        static void ShowMostListeningTracksInAlbum(ApplicationContext db)
        {
            db.Tracks.Include(t => t.RateOfTrack).Load();
            var tracks = db.Tracks.Local;
            double avg = tracks.Average(track => track.Duration.TotalMilliseconds);
            TimeSpan averageDuration = TimeSpan.FromMilliseconds(avg);

            Console.WriteLine($"Average duration = {averageDuration}");
            foreach (var track in db.Tracks.Local)
            {
                if (averageDuration < track.Duration)
                    Console.WriteLine($"{track.Name} rate - {track.RateOfTrack?.Rate}. Duration - {track.Duration}");
            }
        }
        
        static void AddPlaylistToDb(Playlist playlist, ApplicationContext db)
        {
            db.Playlists.Add(playlist);
        }
    }
}