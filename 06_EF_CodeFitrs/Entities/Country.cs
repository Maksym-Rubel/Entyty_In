﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_EF_CodeFitrs.Entities
{
    public class Country
    {
        public Country() 
        {
            Workers = new List<Worker>();
        }
        public int Id { get; set; }
        public string Name { get; set; }


        //Navagition property
        public ICollection<Worker> Workers { get; set; }

    }
}
