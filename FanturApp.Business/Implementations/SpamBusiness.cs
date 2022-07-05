using FanturApp.Business.Interfaces;
using FanturApp.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.Business.Implementations
{
    public class SpamBusiness : ISpamBusiness
    {
        private readonly ISpamDataAccess _spamDataAccess;

        public SpamBusiness(ISpamDataAccess spamDataAccess)
        {
            _spamDataAccess = spamDataAccess;
        }

        public ICollection<string> GetSubUsersEmails()
        {
            return _spamDataAccess.GetSubUsersEmails();
        }
    }
}
