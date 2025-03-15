using _08_DZ_Claasss.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_DZ_Claasss
{
    public static class InitializerDb
    {
        public static void SeedAccounts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>().HasData(new Accounts[]
                {
                    new Accounts() {Id = 1, Login = "Alice123", Password = "SecurePass1", ClientsId = 1},
                    new Accounts() {Id = 2, Login = "BobTraveler", Password = "Travel2024", ClientsId = 2},
                    new Accounts() {Id = 3, Login = "CharlieJet", Password = "JetSetGo", ClientsId = 3},
                }
                );
        }
        public static void SeedAirPlanes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirPlanes>().HasData(new AirPlanes[]
                {
                    new AirPlanes() {Id = 1, Model = "Boeing 747", Type = "Passenger", MaxPassager = 660, Country = "USA", FlightsId = 1},
                    new AirPlanes() {Id = 2, Model = "Airbus A320", Type = "Passenger", MaxPassager = 180, Country = "France", FlightsId = 2},
                    new AirPlanes() {Id = 3, Model = "Embraer E195", Type = "Regional", MaxPassager = 120, Country = "Brazil", FlightsId = 3},
        
                }
                );
        }
        public static void SeedClients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>().HasData(new Clients[]
                {
                    new Clients() {Id = 1, Name = "Alice", Surname = "Johnson", Email = "alice.johnson@example.com", FlightsId = 1, Stat = "Woman"},
                    new Clients() {Id = 2, Name = "Bob", Surname = "Smith", Email = "bob.smith@example.com", FlightsId = 2, Stat = "Men"},
                    new Clients() {Id = 3, Name = "Charlie", Surname = "Brown", Email = "charlie.brown@example.com", FlightsId = 3, Stat = "Men"},
                }
                );
        }
        public static void SeedFlights(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flights>().HasData(new Flights[]
                {
                    new Flights() {Number = 1, StartDate = new DateTime(2025,05,10), EndDate = new DateTime(2025,05,11), StartPlace = "Kyiv", EndPlace = "New York"},
                    new Flights() {Number = 2, StartDate = new DateTime(2025,06,15), EndDate = new DateTime(2025,06,16), StartPlace = "London", EndPlace = "Tokyo"},
                    new Flights() {Number = 3, StartDate = new DateTime(2025,07,20), EndDate = new DateTime(2025,07,21), StartPlace = "Berlin", EndPlace = "Dubai"}
                }
                );
        }

    }
}
