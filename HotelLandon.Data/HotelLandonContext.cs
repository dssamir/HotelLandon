using HotelLandon.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelLandon.Data
{
    public class HotelLandonContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelLandon;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(p => p.FirstName)
                .IsRequired();
            modelBuilder.Entity<Customer>()
                .Property(p => p.LastName)
                .HasMaxLength(50);

            base.OnModelCreating(modelBuilder);
        }
    }
}