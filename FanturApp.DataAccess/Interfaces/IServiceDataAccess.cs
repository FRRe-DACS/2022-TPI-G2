using FanturApp.CrossCutting.Models;

namespace FanturApp.DataAccess.Interfaces
{
    public interface IServiceDataAccess
    {
        public ICollection<Service> GetServices();
        public ICollection<ServiceCategory> GetServiceCategories();
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
