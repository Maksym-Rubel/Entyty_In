using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_EF_CodeFitrs.Entities
{
    public class Worker
    {
        public Worker()
        {
            Projects = new List<Project>();
        }
        [Key] // = primary key
        [Column("Id")]

        public int Number { get; set; }
        [MaxLength(100)]
        [Required]
        [Column("FirstName")]
        public string Name { get; set; }
        [MaxLength(50),Column("LastName"),Required]
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public double Salary { get; set; }

        //
        public int DepartmentId {  get; set; }
        public int CountryId { get; set; }

        public string FullName { get => Name + " " + Surname; }
        [NotMapped]
        public string Email { get; set; }
        //

        public Department Department { get; set; }
        public Country Country { get; set; }

        public ICollection<Project> Projects { get; set; }


    }
}
