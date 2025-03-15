using _06_EF_CodeFitrs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_EF_CodeFitrs
{
    public class Company_db : DbContext
    {
        public Company_db() 
        {
            //this.Database.EnsureDeleted();

            //this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JELVTGO\SQLEXPRESS;
                                        Initial Catalog = Company_PV_421;
                                        Integrated Security=True;
                                        Connect Timeout=2;Encrypt=False;
                                         Trust Server Certificate=False;
                                        Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().ToTable("Position");
            modelBuilder.Entity<Department>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);
            modelBuilder.Entity<Department>()
                .Property(x => x.Prone)
                .IsRequired(false)
                .HasMaxLength(50)
                .IsFixedLength()
                .IsUnicode(false);
            modelBuilder.Entity<Worker>().HasKey(x => x.Number);
            modelBuilder.Entity<Worker>()
                .Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("FirstName");

            // 1 ..... * 
            modelBuilder.Entity<Worker>()
                .HasOne(c => c.Country)
                .WithMany(w => w.Workers)
                .HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<Worker>()
               .HasOne(c => c.Department)
               .WithMany(w => w.Workers)
               .HasForeignKey(c => c.DepartmentId);
            modelBuilder.Entity<Worker>()
               .HasMany(c => c.Projects)
               .WithMany(w => w.Workers);
               

            modelBuilder.SeedCountries();
            modelBuilder.SeedDepartaments();
            modelBuilder.SeedProject();
            modelBuilder.SeedWorkers();

        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Country> Countries { get; set; }
    }

    

}
