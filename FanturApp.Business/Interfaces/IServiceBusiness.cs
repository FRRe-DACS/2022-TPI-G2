using FanturApp.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.Business.Interfaces
{
    public interface IServiceBusiness
    {
        public ICollection<Service> GetServices();
        public Service GetService(int id);
        public Service GetService(string name);
        public bool ServiceExists(int id);
        public ICollection<Package> GetPackagesByService(int id);

        public ServiceCategory GetCategory(int id);
        //post
        bool CreateService(Service service);
        bool Save();
        //update

        public bool UpdateService(Service service);
        public bool DeleteService(Service service);
    }
}

