using FanturApp.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.DataAccess.Interfaces
{
    public interface IPackageDataAccess
    {
        public ICollection<Package> GetPackages();
        public Package GetPackage(int id);
        public Package GetPackage(string name);
        public bool PackageExists(int id);
        public ICollection<Service> GetServicesByPackage(int id);

        //post
        bool CreatePackage(List<int> serviceid, Package package);
        bool Save();

        //update

        public bool UpdatePackage(List<int> serviceid, Package package);
    }
}
