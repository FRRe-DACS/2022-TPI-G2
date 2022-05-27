using FanturApp.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.Business.Interfaces
{
    public interface IPassengerBusiness
    {
        public ICollection<Passenger> GetPassengers();
        public Passenger GetPassenger(int id);
        public bool PassengerExists(int id);
        public User GetUserByPassenger(int id);
        //post
        bool CreatePassenger(Passenger passenger);
        bool Save();
        //update

        public bool UpdatePassenger(Passenger passenger);
        public bool DeletePassenger(Passenger passenger);
    }
}
