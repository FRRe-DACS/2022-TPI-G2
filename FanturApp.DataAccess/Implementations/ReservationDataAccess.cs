using FanturApp.DataAccess.Context;
using FanturApp.DataAccess.Interfaces;
using FanturApp.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.DataAccess.Implementations
{
    public class ReservationDataAccess : IReservationDataAccess
    {
        private readonly DataContext _context;

        public ReservationDataAccess(DataContext context)
        {
            _context = context;
        }
        public ICollection<Package> GetPackagesByReservation(int id)
        {
            return _context.PackageReservations.Where(pr => pr.ReservationId == id).Include(pr => pr.Package).Select(p => p.Package).ToList();
        }

        public ICollection<Passenger> GetPassengersByReservation(int id)
        {
            return _context.PassengerReservations.Where(pr => pr.ReservationId == id).Include(pr => pr.Passenger).Select(p => p.Passenger).ToList();
        }

        public Reservation GetReservation(int id)
        {
            return _context.Reservations.SingleOrDefault(r => r.Id == id);
        }

        public ICollection<Reservation> GetReservationsByStatus(string status)
        {
            return _context.Reservations.Where(r => r.Status == status).ToList();
        }

        public ICollection<Reservation> GetReservations()
        {
            return _context.Reservations.OrderBy(r => r.Id).ToList();
        }

        public User GetUserByReservation(int id)
        {
            return _context.Reservations.Where(r => r.Id == id).Select(r => r.User).FirstOrDefault();
        }

        public bool ReservationExists(int id)
        {
            return _context.Reservations.Any(r => r.Id == id);
        }

        public bool CreateReservation(int passengerid, List<int> packageid, Reservation reservation)
        {
            
            var passengerReservationEntity = _context.Passengers.SingleOrDefault(ps => ps.Id == passengerid);

            var passengerReservation = new PassengerReservation
            {
                Passenger = passengerReservationEntity,
                Reservation = reservation,
            };

            _context.Add(passengerReservation);

            foreach (var pid in packageid)
            {


                var packageReservationEntity = _context.Packages.SingleOrDefault(c => c.Id == pid);
                var packageReservation = new PackageReservation
                {
                    Package = packageReservationEntity,
                    Reservation = reservation,
                };

                _context.Add(packageReservation);

            }

            _context.Add(reservation);

            return Save();

        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdateReservation(int passengerid, List<int> packageid, Reservation reservation)
        {
            var passengerReservationEntity = _context.Passengers.SingleOrDefault(ps => ps.Id == passengerid);

            if (passengerReservationEntity != null)
            {
                var passengerReservation = new PassengerReservation
                {
                    Passenger = passengerReservationEntity,
                    Reservation = reservation,
                };
                _context.Add(passengerReservation);

            }

            if (packageid != null)
            {
                foreach (var pid in packageid)
                {


                    var packageReservationEntity = _context.Packages.SingleOrDefault(c => c.Id == pid);
                    var packageReservation = new PackageReservation
                    {
                        Package = packageReservationEntity,
                        Reservation = reservation,
                    };

                    _context.Add(packageReservation);

                }
            }
            _context.Update(reservation);
            return Save();
        }
    }
}
