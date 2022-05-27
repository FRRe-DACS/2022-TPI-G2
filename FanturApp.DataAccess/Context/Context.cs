using FanturApp.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.DataAccess.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageService> PackageServices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategory { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<PassengerReservation> PassengerReservations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<PackageReservation> PackageReservations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PackageService>()
                .HasKey(ps => new { ps.PackageId, ps.ServiceId});
            modelBuilder.Entity<PackageService>()
                .HasOne(p => p.Package)
                .WithMany(ps => ps.PackageServices)
                .HasForeignKey(p => p.PackageId);
            modelBuilder.Entity<PackageService>()
               .HasOne(s => s.Service)
               .WithMany(ps => ps.PackageServices)
               .HasForeignKey(s => s.ServiceId);

            modelBuilder.Entity<PassengerReservation>()
                .HasKey(pr => new { pr.PassengerId, pr.ReservationId });
            modelBuilder.Entity<PassengerReservation>()
                .HasOne(p => p.Passenger)
                .WithMany(pr => pr.PassengerReservations)
                .HasForeignKey(p => p.PassengerId);
            modelBuilder.Entity<PassengerReservation>()
               .HasOne(r => r.Reservation)
               .WithMany(pr => pr.PassengerReservations)
               .HasForeignKey(r => r.ReservationId);

            modelBuilder.Entity<PackageReservation>()
                .HasKey(pr => new { pr.PackageId, pr.ReservationId });
            modelBuilder.Entity<PackageReservation>()
                .HasOne(p => p.Package)
                .WithMany(pr => pr.PackageReservations)
                .HasForeignKey(p => p.PackageId);
            modelBuilder.Entity<PackageReservation>()
               .HasOne(r => r.Reservation)
               .WithMany(pr => pr.PackageReservations)
               .HasForeignKey(r => r.ReservationId);




        }
    }
}
