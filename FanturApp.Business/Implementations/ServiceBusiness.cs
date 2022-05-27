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
    public class ServiceBusiness : IServiceBusiness
    {
        private readonly IServiceDataAccess _serviceDataAccess;
        public ServiceBusiness(IServiceDataAccess serviceDataAccess)
        {
            _serviceDataAccess = serviceDataAccess;
        }

        public Service GetService(int id)
        {
            return _serviceDataAccess.GetService(id);
        }

        public ICollection<Service> GetServices()
        {
            return _serviceDataAccess.GetServices();
        }

        public ICollection<Package> GetPackagesByService(int id)
        {
            return _serviceDataAccess.GetPackagesByService(id);
        }

        public bool ServiceExists(int id)
        {
            return _serviceDataAccess.ServiceExists(id);
        }

        public Service GetService(string name)
        {
            return _serviceDataAccess.GetService(name);
        }

        public bool CreateService(Service service)
        {
            return _serviceDataAccess.CreateService(service);
        }

        public bool Save()
        {
            return _serviceDataAccess.Save();
        }

        public ServiceCategory GetCategory(int id)
        {
            return _serviceDataAccess.GetCategory(id);
        }

        public bool UpdateService(Service service)
        {
            return _serviceDataAccess.UpdateService(service);
        }

        public bool DeleteService(Service service)
        {
            return _serviceDataAccess.DeleteService(service);
        }
    }
}
