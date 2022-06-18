using FanturApp.CrossCutting.Models;

namespace FanturApp.DataAccess.Interfaces
{
    public interface IUserDataAccess
    {
        //get
        public ICollection<User> GetUsers();
        public User GetUser(int id);
        public bool UserExists(int id);
        public ICollection<Passenger> GetPassengersByUser(int id);
        public ICollection<Reservation> GetReservationsByUser(int id);
        public User GetUserByUsernameAndPassword (string username, string password);

        //post
        bool CreateUser(User user);
        bool Save();

        //update

        public bool UpdateUser(User user);
        public bool DeleteUser(User user);
    }
}
