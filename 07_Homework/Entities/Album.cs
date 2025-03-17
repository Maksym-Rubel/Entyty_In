using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Homework.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public int Year { get; set; }

        public float Rating { get; set; } = 0.0f;
        public int GenreId { get; set; }
        public ICollection<Song> Songs { get; set; }


        public Artist Artist { get; set; }
        public Genre Genre { get; set; }


    }
}
