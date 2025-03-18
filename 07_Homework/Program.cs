using _07_Homework;
using _07_Homework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

internal class Program
{

    public static void AddSongToPlaylist(Music_db context)
    {
        Console.Write("Ведіть назву пісні --> ");
        string a;
        a = Console.ReadLine()!;

        var ssong = context.Songs.FirstOrDefault(s => s.Name == a);
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
    public static void PrintAlbum(Music_db context)
    {
        Console.Write("Введіть назву альбома --> ");
        string playlistName = Console.ReadLine()!;

        var playlist = context.Albums.Include(p => p.Songs).FirstOrDefault(s => s.Name == playlistName);
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

        Console.WriteLine($"-------{playlist.Name}-------{playlist.Rating}");
        Console.WriteLine($"Name              Duration");
        foreach (var song in playlist.Songs)
        {

            Console.WriteLine($"{song.Name,-20}{song.Duration,-10}{song.Rating,-10}{song.Listening,-15}\n{song.SongText,-100}");
        }

    }
    public static void AddPlaylist(Music_db context)
    {
        Console.Write("Введіть назву плейлиста --> ");
        string playlistName = Console.ReadLine()!;
        Console.Write("Введіть категорію плейлиста --> ");
        int category = int.Parse(Console.ReadLine()!);
        context.Playlists.Add(new Playlist { Name = playlistName, CategoryId = category });
        context.SaveChanges();
    }
    public static void UpdateAlbumRatting(Music_db context)
    {
        Console.Write("Введіть назву плейлиста --> ");
        string playlistName = Console.ReadLine()!;
        var album = context.Albums.Include(a => a.Songs).FirstOrDefault(a => a.Name == playlistName);
        if (album != null)
        {
            album.Rating = album.Songs.Average(a => a.Rating);
            context.SaveChanges();
        }
    }
    public static void AddSongRatting(Music_db context)
    {
        Console.Write("Ведіть назву пісні --> ");
        string a;
        a = Console.ReadLine()!;
        Console.Write("Ведіть новий рейтинг пісні --> ");
        float b;
        b = float.Parse(Console.ReadLine()!);
        var track = context.Songs.FirstOrDefault(b => b.Name == a);
        if (track != null)
        {
            track.Rating = b;
            context.SaveChanges();
            UpdateAlbumRatting(context);
        }
    }
    public static void AddSongListening(Music_db context)
    {
        Console.Write("Ведіть назву пісні --> ");
        string a;
        a = Console.ReadLine()!;
        Console.Write("Ведіть кількість прослуховувань пісні --> ");
        int b;
        b = int.Parse(Console.ReadLine()!);
        var track = context.Songs.FirstOrDefault(b => b.Name == a);
        if (track != null)
        {
            track.Listening = b;
            context.SaveChanges();

        }
    }
    public static void AddSongText(Music_db context)
    {
        Console.Write("Ведіть назву пісні --> ");
        string a;
        a = Console.ReadLine()!;
        Console.Write("Ведіть текст пісні --> ");
        string b;
        b = Console.ReadLine()!;
        var track = context.Songs.FirstOrDefault(b => b.Name == a);
        if (track != null)
        {
            track.SongText = b;
            context.SaveChanges();

        }
    }
    public static void PrintSongLitensMore(Music_db context)
    {
        Console.Write("Введіть назву альбома --> ");
        string playlistName = Console.ReadLine()!;

        var album = context.Albums.FirstOrDefault(s => s.Name == playlistName);
        Console.WriteLine($"-------{album.Name,-25}-- Rating -> {album.Rating,-1} <- -------");
        Console.WriteLine($"Name\t\t\tDuration   Rating");
        context.Entry(album).Collection(nameof(Album.Songs)).Load();
        foreach (var song in album.Songs)
        {
            if (song.Listening > album.Songs.Average(a => a.Listening))
                Console.WriteLine($"{song.Name,-25}{song.Duration,-10}{song.Rating,-10}{song.Listening,-15}\nText --> {song.SongText,-100}");
        }
    }
    public static void PrintAlbumLitensMore(Music_db context)
    {
        Console.Write("Введіть артиста --> ");
        string ArtName = Console.ReadLine()!;
        var artist = context.Artist.FirstOrDefault(a => a.Name == ArtName);
        if (artist != null)
        {
            int artid = artist.Id;
            var albums = context.Albums
            .Where(a => a.ArtistId == artid)
            .OrderByDescending(a => a.Rating)
            .Take(3)
            .ToList();
            Console.WriteLine($"\nТОП-3 альбоми артиста {artist.Name}:\n");

            foreach (var album in albums)
            {
                Console.WriteLine($"{album.Name,-30} | Рейтинг: {album.Rating}");

            }



        }

    }
    public static void PrintSongArtist(Music_db context)
    {
        Console.Write("Введіть артиста --> ");
        string ArtName = Console.ReadLine()!;
        var artist = context.Artist.FirstOrDefault(a => a.Name == ArtName);
        if (artist != null)
        {
            int artid = artist.Id;
            var albums = context.Albums
            .Where(a => a.ArtistId == artid)
            .OrderByDescending(a => a.Rating)
            .Take(3)
            .ToList();
            Console.WriteLine($"\nТОП-3 альбоми артиста {artist.Name}:\n");
            List<Song> list = new List<Song>();
            foreach (var album in albums)
            {
                context.Entry(album).Collection(a => a.Songs).Load();
                var topSongs = album.Songs
                .OrderByDescending(s => s.Rating)
                .Take(3)
                .ToList();
                
                if (topSongs.Any())
                {
                    foreach (var song in topSongs)
                    {
                        list.Add(song);
                    }
                }
                list.Sort((a, b) => b.Rating.CompareTo(a.Rating));
                
            }
            Console.WriteLine($"\nТОП-3 пісні артиста {artist.Name}:\n");
            
                foreach (var song in list.Take(3))
                {

                    Console.WriteLine(song.Name, song.Rating);
                }
            
            



        }
    }
    public static void SearchSongName(Music_db context)
    {
        Console.Write("Введіть назву пісні --> ");
        string playlistName = Console.ReadLine()!;

        var songs = context.Songs.Where(s => s.Name.Contains(playlistName));
        foreach (var song in songs)
        {
            Console.WriteLine($"{song.Name,-25}{song.Duration,-10}{song.Rating,-10}{song.Listening,-15}\nText --> {song.SongText,-100}");
        }
    }
    public static void SearchSongText(Music_db context)
    {
        Console.Write("Введіть текст пісні --> ");
        string playlistName = Console.ReadLine()!;

        var songs = context.Songs.Where(s => s.SongText.Contains(playlistName));
        foreach (var song in songs)
        {
            Console.WriteLine($"{song.Name,-25}{song.Duration,-10}{song.Rating,-10}{song.Listening,-15}\nText --> {song.SongText,-100}");
        }
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



            ////context.Workers.FirstOrDefault(n => n.Name == "Emma").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "Tetris"));

            ////context.Playlists.FirstOrDefault(n => n.Id == playlist.Id).Songs.Add(context.Songs.FirstOrDefault(s => s.Id == ssong.Id));




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
        //AddSongRatting(context);
        //AddSongListening(context);
        //AddSongText(context);
        //PrintAlbum(context);
        //PrintSongLitensMore(context);
        //while (true) 
        //{
        //    Console.WriteLine("Виберіть Дію [1] - Додати пісню,[2] - Показати плейлист, [3] - Створити плейлист");
        //    int a = int.Parse(Console.ReadLine());
        //    switch (a)
        //    {
        //        case 1:
        //            AddSongToPlaylist(context);
        //            Console.WriteLine();
        //            break;
        //        case 2:
        //            PrintPlaylist(context);
        //            Console.WriteLine();

        //            break;
        //        case 3:
        //            AddPlaylist(context);
        //            Console.WriteLine();

        //            break;
        //        case 0:
        //            return;
        //    }
        //}
        //AddSongToPlaylist(context);
        //PrintPlaylist(context);




        //Task 1
        PrintSongLitensMore(context);
        //Task 2
        PrintAlbumLitensMore(context);
        PrintSongArtist(context);
        //Task 3
        SearchSongName(context);
        SearchSongText(context);


    }

}