using FanturApp.CrossCutting.Models;
using FanturApp.DataAccess.Context;
using FanturApp.DataAccess.Interfaces;

namespace FanturApp.DataAccess.Implementations
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly DataContext _context;

        public UserDataAccess(DataContext context)
        {
            _context = context;
        }

        public bool CreateUser(User user)
        {
            user.Role = "Customer";
            _context.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }

        public ICollection<Passenger> GetPassengersByUser(int id)
        {
            return _context.Passengers.Where(p => p.User.Id == id).ToList();
        }

        public ICollection<Reservation> GetReservationsByUser(int id)
        {
            return _context.Reservations.Where(r => r.User.Id == id).ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.Users.FirstOrDefault(o => o.UserName.ToLower() == username.ToLower() && o.PassWord == password);
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(u => u.Id).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }
    }
}
