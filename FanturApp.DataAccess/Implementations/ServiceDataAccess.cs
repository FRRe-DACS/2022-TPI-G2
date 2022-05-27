using FanturApp.DataAccess.Context;
using FanturApp.DataAccess.Interfaces;
using FanturApp.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.DataAccess.Implementations
{
    public class ServiceDataAccess : IServiceDataAccess
    {
        private readonly DataContext _context;
        public ServiceDataAccess(DataContext context)
        {
            _context = context;
        }

        public Service GetService(int id)
        {
            return _context.Services.Include(s => s.Category).SingleOrDefault(c => c.Id == id);
        }

        public ICollection<Service> GetServices()
        {
            return _context.Services.Include(s => s.Category).OrderBy(p => p.Id).ToList();
        }

        public Service GetService(string name)
        {
            return _context.Services.Include(s => s.Category).SingleOrDefault(c => c.Description == name);
        }

        public bool ServiceExists(int id)
        {
            return _context.Services.Any(c => c.Id == id);
        }

        public ICollection<Package> GetPackagesByService(int id)
        {
            return _context.PackageServices.Where(ps => ps.ServiceId == id).Select(p => p.Package).ToList();
        }

        public bool CreateService(Service service)
        {
            _context.Add(service);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public ServiceCategory GetCategory(int id)
        {
            return _context.ServiceCategory.SingleOrDefault(c => c.Id == id);
        }

        public bool UpdateService(Service service)
        {
            _context.Update(service);
            return Save();
        }

        public bool DeleteService(Service service)
        {
            _context.Remove(service);
            return Save();
        }
    }
}
