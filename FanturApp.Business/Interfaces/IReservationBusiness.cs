using FanturApp.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.Business.Interfaces
{
    public interface IReservationBusiness
    {
        public ICollection<Reservation> GetReservations();
        public Reservation GetReservation(int id);
        public bool ReservationExists(int id);
        public ICollection<Package> GetPackagesByReservation(int id);
        public ICollection<Passenger> GetPassengersByReservation(int id);
        public User GetUserByReservation(int id);
        public ICollection<Reservation> GetReservationsByStatus(string status);
        //post
        bool CreateReservation(int passengerid, List<int> packageid, Reservation reservation);
        bool Save();
        //update

        public bool UpdateReservation(int passengerid, List<int> packageid, Reservation reservation);

    }
}
