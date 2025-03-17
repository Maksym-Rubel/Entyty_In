using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Homework.Entities
{
    public class Song
    {
        public Song() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public double Duration { get; set; }
        public Album Album { get; set; }
        public float Rating { get; set; } = 0.0f;
        public int Listening { get; set; } = 0;

        public string SongText { get; set; } = "";

        public ICollection<Playlist> Playlists { get; set; }

    }
}
