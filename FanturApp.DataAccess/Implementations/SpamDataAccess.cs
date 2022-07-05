using FanturApp.CrossCutting.Models;
using FanturApp.DataAccess.Context;
using FanturApp.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.DataAccess.Implementations
{
    public class SpamDataAccess : ISpamDataAccess
    {
        private readonly DataContext _context;
        private readonly IUserDataAccess _userDataAccess;

        public SpamDataAccess(DataContext context, IUserDataAccess userDataAccess)
        {
            _context = context;
            _userDataAccess = userDataAccess;
        }
        public ICollection<string> GetSubUsersEmails()
        {
           var allusers = _userDataAccess.GetUsers();
           var subUsersEmails = new List<string>();

            foreach (User user in allusers)
            {
                if (user.EmailSubscription == true)
                {
                    subUsersEmails.Add(user.Email);
                }
            }

            return subUsersEmails;
        }
    }
}
