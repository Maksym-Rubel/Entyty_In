using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_DZ_Claasss.Entities
{
    public class AirPlanes
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }

        public int MaxPassager { get; set;}
        public string Country { get; set; }
        public int FlightsId { get; set; }
        public Flights Flights { get; set; }


    }
}
