using FanturApp.Business.Interfaces;
using FanturApp.DataAccess.Interfaces;
using FanturApp.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
