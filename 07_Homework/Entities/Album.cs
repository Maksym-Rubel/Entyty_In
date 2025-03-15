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

        public int GenretId { get; set; }

        public Artist Artist { get; set; }
        public Genre Genre { get; set; }


    }
}
