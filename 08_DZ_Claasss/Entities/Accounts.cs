using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_DZ_Claasss.Entities
{
    public class Accounts
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int ClientsId { get; set; }

        public Clients Clients { get; set; }

    }
}
