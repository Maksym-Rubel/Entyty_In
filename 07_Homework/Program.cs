using _07_Homework;
using _07_Homework.Entities;

internal class Program
{

    public void AddSongToPlaylist(Music_db context)
    {
        Console.Write("Ведіть назву пісні --> ");
        string a;
        a = Console.ReadLine()!;

        var ssong = context.Songs.FirstOrDefault(s=> s.Name == a);


        Console.Write("Введіть назву плейлиста --> ");
        string playlistName = Console.ReadLine()!;

        var playlist = context.Playlists.FirstOrDefault(s => s.Name == playlistName);

        if (ssong != null && playlist != null)
        {
            context.Playlists.Add(playlist);
            context.SaveChanges();
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

    }
}