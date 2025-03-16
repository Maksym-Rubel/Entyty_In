using _07_Homework;
using _07_Homework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;

internal class Program
{

    public static void AddSongToPlaylist(Music_db context)
    {
        Console.Write("Ведіть назву пісні --> ");
        string a;
        a = Console.ReadLine()!;

        var ssong = context.Songs.FirstOrDefault(s=> s.Name == a);
        if (ssong == null)
        {
            Console.WriteLine("Song not found!");
            return;
        }

        Console.Write("Введіть назву плейлиста --> ");
        string playlistName = Console.ReadLine()!;

        var playlist = context.Playlists.FirstOrDefault(s => s.Name == playlistName);
        if (playlist == null)
        {
            Console.WriteLine("Playlist not found!");
            return;
        }
        if (playlist.Songs == null)
        {
            playlist.Songs = new List<Song>(); 
        }
        playlist.Songs.Add(ssong);
        context.SaveChanges();
    }
    public static void PrintPlaylist(Music_db context)
    {
        Console.Write("Введіть назву плейлиста --> ");
        string playlistName = Console.ReadLine()!;

        var playlist = context.Playlists.Include(p => p.Songs).FirstOrDefault(s => s.Name == playlistName);
        if (playlist == null)
        {
            Console.WriteLine("Playlist not found!");
            return;
        }
        if (playlist.Songs == null || playlist.Songs.Count == 0)
        {
            Console.WriteLine($"Playlist '{playlist.Name}' is empty.");
            return;
        }

        Console.WriteLine($"-------{playlist.Name}-------");
        Console.WriteLine($"Name              Duration");
        foreach (var song in playlist.Songs)
        {
            
            Console.WriteLine($"{song.Name}     {song.Duration}");
        }
        
    }
    public static void AddPlaylist(Music_db context)
    {
        Console.Write("Введіть назву плейлиста --> ");
        string playlistName = Console.ReadLine()!;
        Console.Write("Введіть категорію плейлиста --> ");
        int category = int.Parse(Console.ReadLine()!);
        context.Playlists.Add(new Playlist {Name = playlistName, CategoryId = category });
        context.SaveChanges();
    }
    private static void Main(string[] args)
    {
        Music_db context = new Music_db();
        //var categories = new List<Category>
        //{
        //    new Category {  Name = "Рок" },
        //    new Category { Name = "Поп" },
        //    new Category {  Name = "Джаз" },
        //    new Category { Name = "Класична музика" },
        //    new Category { Name = "Хіп-хоп" }
        //};
        //context.Categories.AddRange(categories);
        //context.SaveChanges();

        //context.Playlists.Add(new Playlist { Name = "SongTest", CategoryId = 1 });
        //context.SaveChanges();



        //context.Workers.FirstOrDefault(n => n.Name == "Emma").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "Tetris"));

        //context.Playlists.FirstOrDefault(n => n.Id == playlist.Id).Songs.Add(context.Songs.FirstOrDefault(s => s.Id == ssong.Id));




        //var genres = new List<Genre>
        //{
        //    new Genre {  Name = "Рок" },
        //    new Genre { Name = "Поп" },
        //    new Genre {  Name = "Джаз" },
        //    new Genre { Name = "Класична музика" },
        //    new Genre { Name = "Хіп-хоп" }
        //};
        //context.Genres.AddRange(genres);
        //context.SaveChanges();
        //var countries = new List<Country>
        //{
        //    new Country {Name = "Україна" },
        //    new Country {Name = "США" },
        //    new Country {Name = "Велика Британія" },
        //    new Country {Name = "Франція" },
        //    new Country {Name = "Німеччина" }
        //};
        //context.Countries.AddRange(countries);

        //context.SaveChanges();
        //context.Artist.AddRange(new Artist { Name = "Metallica", Surname = " ", CountryId = 2 });
        //context.SaveChanges();

        //var albums = new List<Album>
        //{
        //    new Album
        //    {
        //        Name = "Master of Puppets",
        //        ArtistId = 1,
        //        Year = 1986,
        //        GenreId = 1
        //    },
        //    new Album
        //    {
        //        Name = "Metallica (The Black Album)",
        //        ArtistId = 1,
        //        Year = 1991,
        //        GenreId = 1
        //    }
        //};
        //context.Albums.AddRange(albums);
        //context.SaveChanges();
        //var tracks = new List<Song>
        //{
        //    new Song {Name = "Battery", AlbumId = 1, Duration = 5.12},
        //    new Song {Name = "Master of Puppets", AlbumId = 1, Duration = 8.36},
        //    new Song {Name = "Enter Sandman", AlbumId = 2, Duration = 5.32},
        //    new Song {Name = "Nothing Else Matters", AlbumId = 2, Duration = 6.28}
        //};
        //context.Songs.AddRange(tracks);
        //context.SaveChanges();

        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.InputEncoding = UTF8Encoding.UTF8;
        while (true) 
        {
            Console.WriteLine("Виберіть Дію [1] - Додати пісню,[2] - Показати плейлист, [3] - Створити плейлист");
            int a = int.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    AddSongToPlaylist(context);
                    Console.WriteLine();
                    break;
                case 2:
                    PrintPlaylist(context);
                    Console.WriteLine();

                    break;
                case 3:
                    AddPlaylist(context);
                    Console.WriteLine();

                    break;
                case 0:
                    return;
            }
        }
        //AddSongToPlaylist(context);
        //PrintPlaylist(context);
    }
}