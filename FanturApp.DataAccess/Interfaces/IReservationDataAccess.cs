using FanturApp.CrossCutting.Models;

namespace FanturApp.DataAccess.Interfaces
{
    public interface IReservationDataAccess
    {
        public ICollection<Reservation> GetReservations();
        public Reservation GetReservation(int id);
        public bool ReservationExists(int id);
        public ICollection<Package> GetPackagesByReservation(int id);
        public ICollection<Passenger> GetPassengersByReservation(int id);
        public User GetUserByReservation(int id);
        public ICollection<Reservation> GetReservationsByStatus(string status);

        //post
        bool CreateReservation(List<int> passengerid, int packageid, Reservation reservation);
        bool Save();

        //update

        public bool UpdateReservation(int passengerid, List<int> packageid, Reservation reservation);

    }
}
