using FanturApp.CrossCutting.Dtos;
using FanturApp.CrossCutting.Models;

namespace FanturApp.Business.Interfaces
{
    public interface IPackageBusiness
    {
        public ICollection<Package> GetPackages();
        public Package GetPackage(int id);
        public Package GetPackage(string name);
        public bool PackageExists(int id);
        public ICollection<Service> GetServicesByPackage(int id);

        

        //post
        public bool CreatePackage(List<int> serviceid, Package package);
        public bool Save();
        //update

        public bool UpdatePackage(List<int> serviceid, Package package);
    }

}
