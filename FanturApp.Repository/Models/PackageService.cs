using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.Repository.Models
{
    public class PackageService
    {
        public int PackageId { get; set; }
        public Package Package  { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }


     }   
}
