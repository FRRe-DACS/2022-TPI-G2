using FanturApp.CrossCutting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.CrossCutting.Dtos
{
    public class PackageWithServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? PackagePrice { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ValidDate { get; set; }
        public ICollection<PackageServiceDto> PackageServices { get; set; }

    }
}
