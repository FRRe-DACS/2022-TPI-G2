using FanturApp.CrossCutting.Models;
using FanturApp.DataAccess.Context;
using FanturApp.DataAccess.Interfaces;

namespace FanturApp.DataAccess.Implementations
{
    public class PassengerDataAccess : IPassengerDataAccess
    {
        private readonly DataContext _context;

        public PassengerDataAccess(DataContext context)
        {
            _context = context;
        }

        public bool CreatePassenger(Passenger passenger)
        {
            _context.Add(passenger);
            return Save();
        }

        public bool DeletePassenger(Passenger passenger)
        {
            _context.Remove(passenger);
            return Save();
        }

        public Passenger GetPassenger(int id)
        {
            return _context.Passengers.FirstOrDefault(p => p.Id == id);
        }

        public ICollection<Passenger> GetPassengers()
        {
            return _context.Passengers.OrderBy(p => p.FirstName).ToList();
        }

        public User GetUserByPassenger(int id)
        {
            return _context.Passengers.Where(p => p.Id == id).Select(u => u.User).FirstOrDefault();
        }

        public bool PassengerExists(int id)
        {
            return _context.Passengers.Any(p => p.Id == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdatePassenger(Passenger passenger)
        {
            
                _context.Update(passenger);
                return Save();
            
        }
    }
}
