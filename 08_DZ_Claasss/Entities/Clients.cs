using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_DZ_Claasss.Entities
{
    public class Clients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get;set; }
        public int FlightsId { get; set; }
        public string Stat { get; set; }

        public Accounts Accounts { get; set; }

        public Flights Flights { get; set; }


    }
}
