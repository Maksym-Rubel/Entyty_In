using _06_EF_CodeFitrs.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_EF_CodeFitrs
{
    public static class InitializerDb
    {
        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country() {Id = 1 ,Name = "Ukraine"},
                new Country() {Id = 2 ,Name = "USA" },
                new Country() {Id = 3 ,Name = "Poland" }

            });
        }
        public static void SeedDepartaments(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department[]
            {
                new Department() { Id = 1 ,Name = "Management",Prone = "45-45-23412"},
                new Department() { Id = 2, Name = "Programing", Prone = "45-45-23412" },
                new Department() { Id = 3, Name = "Design", Prone = "45-45-23412" }

            });
        }
        public static void SeedWorkers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasData(new Worker[]
            {
                new Worker() { Number = 1,  
                               Name = "Emma",
                               Surname = "Miller",
                               Salary = 2700,
                               Birthdate = new DateTime(2005, 12, 12),
                               CountryId = 1,
                               DepartmentId = 1},
                new Worker() { Number = 2,
                               Name = "Taras",
                               Surname = "Bondar",
                               Salary = 5800,
                               Birthdate = new DateTime(2005, 12, 12),
                               CountryId = 2,
                               DepartmentId = 2},
                new Worker() { Number = 3,
                               Name = "Tomm",
                               Surname = "Doe",
                               Salary = 3200,
                               Birthdate = new DateTime(2012, 1, 13),
                               CountryId = 3,
                               DepartmentId = 3}

            });

        }
        public static void SeedProject(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(new Project[]
            {
                new Project() { Id = 1, Name = "Tetris", LaunchDate = new DateTime(1982, 12, 12)},
                new Project() { Id = 2, Name = "CS", LaunchDate = new DateTime(2000, 1, 1) },
                new Project() { Id = 3, Name = "PacMan", LaunchDate = new DateTime(1999, 3, 3) }

            });
        }

    }
}
