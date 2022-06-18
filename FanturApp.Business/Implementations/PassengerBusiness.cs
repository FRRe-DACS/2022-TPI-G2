using FanturApp.Business.Interfaces;
using FanturApp.CrossCutting.Models;
using FanturApp.DataAccess.Interfaces;

namespace FanturApp.Business.Implementations
{
    public class PassengerBusiness : IPassengerBusiness
    {
        private readonly IPassengerDataAccess _passengerDataAccess;

        public PassengerBusiness(IPassengerDataAccess passengerDataAccess)
        {
            _passengerDataAccess = passengerDataAccess;
        }

        public bool CreatePassenger(Passenger passenger)
        {
            return _passengerDataAccess.CreatePassenger(passenger);
        }

        public bool DeletePassenger(Passenger passenger)
        {
            return _passengerDataAccess.DeletePassenger(passenger);
        }

        public Passenger GetPassenger(int id)
        {
            return _passengerDataAccess.GetPassenger(id);
        }

        public ICollection<Passenger> GetPassengers()
        {
           return _passengerDataAccess.GetPassengers();
        }

        public User GetUserByPassenger(int id)
        {
            return _passengerDataAccess.GetUserByPassenger(id);
        }

        public bool PassengerExists(int id)
        {
            return _passengerDataAccess.PassengerExists(id);    
        }

        public bool Save()
        {
           return _passengerDataAccess.Save();
        }

        public bool UpdatePassenger(Passenger passenger)
        {
            return _passengerDataAccess.UpdatePassenger(passenger);
        }
    }
}
