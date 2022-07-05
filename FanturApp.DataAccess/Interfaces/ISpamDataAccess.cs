using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.DataAccess.Interfaces
{
    public interface ISpamDataAccess
    {
        public ICollection<string> GetSubUsersEmails();
    }
}
