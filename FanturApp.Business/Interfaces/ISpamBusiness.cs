using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.Business.Interfaces
{
     public interface ISpamBusiness
    {
        public ICollection<string> GetSubUsersEmails();
    }
}
