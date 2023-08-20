using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Intro_to_ef
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Track> Tracks { get; set; } = null!;
        public DbSet<Album> Albums { get; set; } = null!;
        public DbSet<Playlist> Playlists { get; set; } = null!;
        public RateOfAlbum RatesOfAlbum { get; set; } = null!;
        public RateOfTrack RatesOfTrack { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                        : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country() { Id = 1, Name = "Ukraine" },
                new Country() { Id = 2, Name = "Italy" },
                new Country() { Id = 3, Name = "Great Britain" },
                new Country() { Id = 4, Name = "France" }
            });
            modelBuilder.Entity<Artist>().HasData(new Artist[]
            {
                new Artist() { Id = 1, Name = "John", Surname = "Doe", CountrieId = 1},
                new Artist() { Id = 2, Name = "Liam", Surname = "Brown", CountrieId = 2},
                new Artist() { Id = 3, Name = "Bread", Surname = "Black", CountrieId = 3},
                new Artist() { Id = 4, Name = "Antua", Surname = "White", CountrieId = 2},
                new Artist() { Id = 5, Name = "Helga", Surname = "Green", CountrieId = 4},
                new Artist() { Id = 6, Name = "Riam", Surname = "Yellow", CountrieId = 4},
            });
            modelBuilder.Entity<Genre>().HasData(new Genre[]
           {
                new Genre() { Id = 1, Name = "Pop"},
                new Genre() { Id = 2, Name = "Rock"},
                new Genre() { Id = 3, Name = "Classic"},
                new Genre() { Id = 4, Name = "Metal"},
                new Genre() { Id = 5, Name = "Hip-Hop"},
           });
            modelBuilder.Entity<Album>().HasData(new Album[]
            {
                new Album() { Id = 1, Name = "Album 1", ArtistId = 1, Year = 1965, GenreId =  1},
                new Album() { Id = 2, Name = "Album 2", ArtistId = 2, Year = 1985, GenreId =  2},
                new Album() { Id = 3, Name = "Album 3", ArtistId = 3, Year = 1967, GenreId =  3},
                new Album() { Id = 4, Name = "Album 4", ArtistId = 4, Year = 1992, GenreId =  4},
                new Album() { Id = 5, Name = "Album 5", ArtistId = 5, Year = 1989, GenreId =  5},
                new Album() { Id = 6, Name = "Album 6", ArtistId = 6, Year = 1983, GenreId =  3},
            });
            modelBuilder.Entity<RateOfTrack>();
            modelBuilder.Entity<RateOfAlbum>();
            modelBuilder.Entity<Track>().Property(u => u.CountListening).HasDefaultValue(0);

            //modelBuilder.Entity<Track>().HasData(new Track[]
            //{
            //    new Track() { Id = 1, Name = "Track01", AlbumId = 1, Duration = new(210)},
            //    new Track() { Id = 2, Name = "Track02", AlbumId = 1, Duration = new(240)},
            //    new Track() { Id = 3, Name = "Track03", AlbumId = 1, Duration = new(230)},
            //    new Track() { Id = 4, Name = "Track04", AlbumId = 1, Duration = new(321)},
            //    new Track() { Id = 5, Name = "Track01", AlbumId = 2, Duration = new(240)},
            //    new Track() { Id = 6, Name = "Track02", AlbumId = 2, Duration = new(250)},
            //    new Track() { Id = 7, Name = "Track03", AlbumId = 2, Duration = new(235)},
            //    new Track() { Id = 8, Name = "Track04", AlbumId = 2, Duration = new(263)},
            //    new Track() { Id = 9, Name = "Track01", AlbumId = 3, Duration = new(290)},
            //    new Track() { Id = 10, Name = "Track02", AlbumId = 3, Duration = new(241)},
            //    new Track() { Id = 11, Name = "Track03", AlbumId = 3, Duration = new(242)},
            //    new Track() { Id = 12, Name = "Track04", AlbumId = 3, Duration = new(263)},
            //    new Track() { Id = 13, Name = "Track01", AlbumId = 4, Duration = new(273)},
            //    new Track() { Id = 14, Name = "Track02", AlbumId = 4, Duration = new(251)},
            //    new Track() { Id = 15, Name = "Track03", AlbumId = 4, Duration = new(279)},
            //    new Track() { Id = 16, Name = "Track04", AlbumId = 4, Duration = new(254)},
            //    new Track() { Id = 17, Name = "Track01", AlbumId = 5, Duration = new(247)},
            //    new Track() { Id = 18, Name = "Track02", AlbumId = 5, Duration = new(263)},
            //    new Track() { Id = 19, Name = "Track03", AlbumId = 5, Duration = new(274)},
            //    new Track() { Id = 20, Name = "Track04", AlbumId = 5, Duration = new(257)},
            //    new Track() { Id = 21, Name = "Track01", AlbumId = 6, Duration = new(264)},
            //    new Track() { Id = 22, Name = "Track02", AlbumId = 6, Duration = new(234)},
            //    new Track() { Id = 23, Name = "Track03", AlbumId = 6, Duration = new(256)},
            //    new Track() { Id = 24, Name = "Track04", AlbumId = 6, Duration = new(227)},
            //});
        }
    }
}
