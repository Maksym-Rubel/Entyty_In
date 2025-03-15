using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Homework.Entities
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Song> Songs { get; set; }

    }
}
