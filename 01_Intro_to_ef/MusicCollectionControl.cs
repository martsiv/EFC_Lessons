using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _01_Intro_to_ef
{
    public class MusicCollectionControl
    {
        private DbContextOptions<ApplicationContext>? options = null;
        public MusicCollectionControl(DbContextOptions<ApplicationContext>? opt = null)
        {
            if (opt != null)
                options = opt;
            else
            {
                var builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json");
                var config = builder.Build();
                string connectionString = config.GetConnectionString("MyDbConnection");

                var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
                options = optionBuilder.UseSqlServer(connectionString).Options;
            }
        }
        public void Run()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine("\t\t\tMusical collection");
            List<string> menuItems = new List<string>
            {
            "Add playlist",
            "Add tracks to playlist",
            "Show most listening tracks in album",
            "Show TOP 3 tracks and albums by Artist",
            "Find track by keywords",
            "Exit"
            };

            int selectedItemIndex = 0;

            while (true)
            {
                Console.Clear();

                for (int i = 0; i < menuItems.Count; i++)
                {
                    if (i == selectedItemIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(menuItems[i]);
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedItemIndex = Math.Max(0, selectedItemIndex - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedItemIndex = Math.Min(menuItems.Count - 1, selectedItemIndex + 1);
                        break;
                    case ConsoleKey.Enter:
                        if (selectedItemIndex == menuItems.Count - 1)
                        {
                            Environment.Exit(0);
                        }
                        else if (selectedItemIndex == 0)
                            AddPlaylist();
                        else if (selectedItemIndex == 1)
                            AddTracksToPlaylist();
                        else if (selectedItemIndex == 2)
                            ShowMostListeningTracksInAlbum();
                        else if (selectedItemIndex == 3)
                            ShowTOP3TracksAndAlbumsByArtist();
                        else if (selectedItemIndex == 4)
                            FindTrackByKeywords();
                        break;
                }
            }
        }
        private void AddPlaylist()
        {
            Console.CursorVisible = true;
            Console.Clear();
            using (ApplicationContext db = new(options))
            {
                Console.WriteLine("Enter new Playlist: ");
                string newNamePlaylist = Console.ReadLine();
                if (db.Playlists.Any(playlist => playlist.Name == newNamePlaylist))
                {
                    Console.WriteLine($"Playlist with name {newNamePlaylist} exist!");
                    return;
                }
                List<Category> categories = db.Categories.ToList();

                Console.WriteLine("Select a category:");
                Category category = ChooseCategory();

                string? pathToImage = null;
                Console.WriteLine("Do you want to add an image path to the playlist?");
                string key = Console.ReadLine();
                if (key[0] == 'y' || key[0] == 'Y')
                {
                    pathToImage = AddImagePath();
                    db.Playlists.Add(new() { Name = newNamePlaylist, CategoryId = category.Id, PathToImage = pathToImage });
                }
                else
                    db.Playlists.Add(new() { Name = newNamePlaylist, CategoryId = category.Id });
                db.SaveChanges();
                Console.WriteLine("Added playlist. Press Enter to return");
                Console.ReadKey();
            }
        }
        private string? AddImagePath()
        {
            Console.WriteLine("Enter the path to image: (e.g. C:\\...)");
            string path = Console.ReadLine();
            return path ?? null;
        }
        private Category ChooseCategory()
        {
            Console.CursorVisible = false;
            Console.Clear();
            using (ApplicationContext db = new(options))
            {
                List<Category> categories = db.Categories.ToList();

                int selectedItemIndex = 0;
                while (true)
                {
                    Console.Clear();

                    for (int i = 0; i < categories.Count + 1; i++)
                    {
                        if (i == selectedItemIndex)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (i < categories.Count)
                            Console.WriteLine(categories[i].Name);
                        else
                            Console.WriteLine("Create new categoty.");
                    }

                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedItemIndex = Math.Max(0, selectedItemIndex - 1);
                            break;
                        case ConsoleKey.DownArrow:
                            selectedItemIndex = Math.Min(categories.Count, selectedItemIndex + 1);
                            break;
                        case ConsoleKey.Enter:
                            if (selectedItemIndex == categories.Count)
                            {
                                return CreateCategory();
                            }
                            else
                                return categories[selectedItemIndex];
                    }
                }
            }
        }
        private Category CreateCategory()
        {
            Console.CursorVisible = true;
            Console.Clear();
            using (ApplicationContext db = new(options))
            {
                string newName;
                do
                {
                    Console.WriteLine("Enter new Category name: ");
                    newName = Console.ReadLine();

                } while (db.Categories.Any(category => category.Name == newName));  //if category exist
                Category newCategory = new Category() { Name = newName };
                db.Categories.Add(newCategory);
                db.SaveChanges();
                Console.WriteLine("Category added. Press Enter to return");
                Console.ReadKey();
                return newCategory;
            }
        }
        private void AddTracksToPlaylist()
        {
            using (ApplicationContext db = new(options))
            {
                Console.CursorVisible = false;
                Console.Clear();
                Console.WriteLine("Choose a playlist:");
                int selectedItemIndex = 0;
                List<Playlist> playlists = db.Playlists.ToList();
                Playlist playlist = null;
                while (playlist == null)
                {
                    Console.CursorVisible = false;
                    Console.Clear();
                    for (int i = 0; i < playlists.Count; i++)
                    {
                        if (i == selectedItemIndex)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }

                        Console.WriteLine(playlists[i]);
                    }

                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedItemIndex = Math.Max(0, selectedItemIndex - 1);
                            break;
                        case ConsoleKey.DownArrow:
                            selectedItemIndex = Math.Min(playlists.Count - 1, selectedItemIndex + 1);
                            break;
                        case ConsoleKey.Enter:
                                playlist = playlists[selectedItemIndex];
                            break;
                    }
                }
                Console.WriteLine("Choose tracks to playlist:");
                selectedItemIndex = 0;
                List<Track> allTracks = db.Tracks
                    .Where(track => !track.Playlists.Any(pl => pl.Id == playlist.Id))
                    .Include(x => x.Album)
                    .ToList(); List<Track> tracksToPlaylist = new List<Track>();
                while (true)
                {
                    Console.CursorVisible = false;
                    Console.Clear();
                    for (int i = 0; i < allTracks.Count + 1; i++)
                    {
                        if (i == selectedItemIndex)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        if (i < allTracks.Count)
                            Console.WriteLine(allTracks[i]);
                        else
                            Console.WriteLine("Return.");
                    }

                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedItemIndex = Math.Max(0, selectedItemIndex - 1);
                            break;
                        case ConsoleKey.DownArrow:
                            selectedItemIndex = Math.Min(allTracks.Count, selectedItemIndex + 1);
                            break;
                        case ConsoleKey.Enter:
                            if (selectedItemIndex == allTracks.Count - 1)
                                Environment.Exit(0);
                            else if (selectedItemIndex < allTracks.Count)
                            {
                                tracksToPlaylist.Add(allTracks[selectedItemIndex]);
                                allTracks.RemoveAt(selectedItemIndex);
                            }
                            else if (selectedItemIndex == allTracks.Count)
                            {
                                Console.WriteLine("Tracks added to playlist:");
                                foreach (var track in tracksToPlaylist)
                                {
                                    Console.WriteLine(track);
                                    playlist.Tracks.Add(track);
                                }
                                db.SaveChanges();
                                return;
                            }
                            break;
                    }
                }
            }
        }
        private void ShowMostListeningTracksInAlbum()
        {
            Console.CursorVisible = true;
            Console.Clear();
            //Переробити на такий, який не втягує всі треки в базу
            //Взагалі переробити щоб можна було альбом обирати
            using (ApplicationContext db = new(options))
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
            Console.WriteLine("Press Enter to return");
            Console.ReadKey();
        }
        private void ShowTOP3TracksAndAlbumsByArtist()
        {
            Console.CursorVisible = true;
            Console.Clear();
            using (ApplicationContext db = new(options))
            {
                Console.WriteLine("Enter the name of artist: ");
                string s_artist = Console.ReadLine();
                var artist = db.Artists.Where(x => x.Name.Contains(s_artist) == true || x.Surname.Contains(s_artist)).Include(x => x.Countrie).FirstOrDefault();
                Console.WriteLine(artist?.ToString());
                Console.WriteLine("Press Enter to return");
                Console.ReadKey();
            }
        }
        private void FindTrackByKeywords()
        {
            Console.CursorVisible = true;
            Console.Clear();
            using (ApplicationContext db = new(options))
            {
                Console.WriteLine("Enter the keyword to search: ");
                string keywords = Console.ReadLine();
                List<Track> tracks = db.Tracks.Where(x => x.Name.Contains(keywords) || x.Text.Contains(keywords)).Include(x => x.Album).ToList();
                if (tracks.Count == 0)
                    Console.WriteLine("No tracks found");
                else if (tracks.Count == 1)
                    Console.WriteLine(tracks[0]);
                else
                {
                    Console.WriteLine("All tracks:");
                    foreach (var track in tracks)
                        Console.WriteLine(track);
                }
                Console.WriteLine("Press Enter to return");
                Console.ReadKey();
            }
        }
    }
}
