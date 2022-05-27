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
        public class PackageBusiness : IPackageBusiness
        {
            private readonly IPackageDataAccess _packageDataAccess;
            public PackageBusiness(IPackageDataAccess packageDataAccess)
            {
                _packageDataAccess = packageDataAccess;
            }

        public bool CreatePackage(List<int> serviceid, Package package)
        {
            return _packageDataAccess.CreatePackage(serviceid, package);
        }

        public Package GetPackage(int id)
            {
                return _packageDataAccess.GetPackage(id);
            }

            public Package GetPackage(string name)
            {
                return _packageDataAccess.GetPackage(name);
            }

             public ICollection<Package> GetPackages()
            {
                return _packageDataAccess.GetPackages();
            }

             public ICollection<Service> GetServicesByPackage(int id)
            {
                return _packageDataAccess.GetServicesByPackage(id);
            }

            public bool PackageExists(int id)
            {
                return _packageDataAccess.PackageExists(id);
            }

        public bool Save()
        {
            return _packageDataAccess.Save();
        }

        public bool UpdatePackage(List<int> serviceid, Package package)
        {
            return _packageDataAccess.UpdatePackage(serviceid, package);
        }
    }
    
}
