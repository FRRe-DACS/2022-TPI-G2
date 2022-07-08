using FanturApp.Business.Interfaces;
using FanturApp.CrossCutting.Models;
using FanturApp.DataAccess.Interfaces;

namespace FanturApp.Business.Implementations
{
    public class ReservationBusiness : IReservationBusiness
    {
        private readonly IReservationDataAccess _reservationDataAccess;

        public ReservationBusiness(IReservationDataAccess reservationDataAccess)
        {
            _reservationDataAccess = reservationDataAccess;
        }

        public bool CreateReservation(List<int> passengerid, int packageid, Reservation reservation)
        {
            return _reservationDataAccess.CreateReservation(passengerid, packageid, reservation);
        }

        public Reservation GetLastReservation()
        {
            return _reservationDataAccess.GetLastReservation();
        }

        public ICollection<Package> GetPackagesByReservation(int id)
        {
            return _reservationDataAccess.GetPackagesByReservation(id);
        }

        public ICollection<Passenger> GetPassengersByReservation(int id)
        {
            return _reservationDataAccess.GetPassengersByReservation(id);
        }

        public Reservation GetReservation(int id)
        {
            return _reservationDataAccess.GetReservation(id);
        }

        public ICollection<Reservation> GetReservations()
        {
            return _reservationDataAccess.GetReservations();
        }

        public ICollection<Reservation> GetReservationsByStatus(string status)
        {
            return _reservationDataAccess.GetReservationsByStatus(status);
        }

        public User GetUserByReservation(int id)
        {
            return _reservationDataAccess.GetUserByReservation(id);
        }

        public bool ReservationExists(int id)
        {
            return _reservationDataAccess.ReservationExists(id);
        }

        public bool Save()
        {
            return _reservationDataAccess.Save();
        }

        public bool UpdateReservation(int passengerid, List<int> packageid, Reservation reservation)
        {
            return _reservationDataAccess.UpdateReservation(passengerid, packageid, reservation);
        }
    }
}
