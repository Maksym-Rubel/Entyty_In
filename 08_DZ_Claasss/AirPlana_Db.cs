using _08_DZ_Claasss.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_DZ_Claasss
{
    internal class AirPlana_Db : DbContext
    {
        public AirPlana_Db()
        {
            this.Database.EnsureDeleted();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JELVTGO\SQLEXPRESS;
                                        Initial Catalog = AirPlane_PV_421;
                                        Integrated Security=True;
                                        Connect Timeout=2;Encrypt=False;
                                         Trust Server Certificate=False;
                                        Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            

            modelBuilder.Entity<AirPlanes>()
               .HasOne(c => c.Flights)
               .WithOne(w => w.AirPlanes);



            modelBuilder.Entity<Clients>()
               .HasOne(c => c.Flights)
               .WithMany(w => w.Clients)
               .HasForeignKey(c=> c.FlightsId);
            modelBuilder.Entity<Accounts>()
               .HasOne(c => c.Clients)
               .WithOne(w => w.Accounts);

            modelBuilder.SeedFlights();
            modelBuilder.SeedClients();
            modelBuilder.SeedAccounts();
            modelBuilder.SeedAirPlanes();
           
        }
        public DbSet<AirPlanes> AirPlanes { get; set; }
        public DbSet<Accounts> Accounts { get; set; }

        public DbSet<Clients> Clients { get; set; }
        public DbSet<Flights> Flights { get; set; }
    }
}
