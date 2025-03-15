using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_DZ_Claasss.Entities
{
    public class Flights
    {
        [Key]
        public int Number { get; set; }
        
        public AirPlanes AirPlanes { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string StartPlace { get; set; }
        public string EndPlace { get;set; }

        public ICollection<Clients> Clients { get; set; }
    }
}
