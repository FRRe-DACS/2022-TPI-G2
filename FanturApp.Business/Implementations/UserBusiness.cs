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
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserDataAccess _userDataAccess;

        public UserBusiness(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public bool CreateUser(User user)
        {
            return _userDataAccess.CreateUser(user);
        }

        public bool DeleteUser(User user)
        {
            return _userDataAccess.DeleteUser(user);
        }

        public ICollection<Passenger> GetPassengersByUser(int id)
        {
           return _userDataAccess.GetPassengersByUser(id);
        }

        public ICollection<Reservation> GetReservationsByUser(int id)
        {
            return _userDataAccess.GetReservationsByUser(id);
        }

        public User GetUser(int id)
        {
            return _userDataAccess.GetUser(id);
        }

        public ICollection<User> GetUsers()
        {
            return _userDataAccess.GetUsers();
        }

        public bool Save()
        {
            return _userDataAccess.Save();
        }

        public bool UpdateUser(User user)
        {
            return _userDataAccess.UpdateUser(user);
        }

        public bool UserExists(int id)
        {
            return _userDataAccess.UserExists(id);
        }
    }
}
