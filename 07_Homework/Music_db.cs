using _07_Homework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Homework
{
    public class Music_db : DbContext
    {
        public Music_db() 
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-JELVTGO\SQLEXPRESS;
                                        Initial Catalog = Songers2;
                                        Integrated Security = True;
                                        Connect Timeout = 2;
                                        Encrypt = False;
                                        Trust Server Certificate = False;
                                        Application Intent = ReadWrite;
                                        Multi Subnet Failover = False");
        }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        //public DbSet<PlaylistTrack> PlaylistTracks { get; set; }


    }
}
