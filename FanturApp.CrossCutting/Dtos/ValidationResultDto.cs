using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.CrossCutting.Dtos
{
    public class ValidationResultDto
    {
        public int id { get; set; }
        public long cuit { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_incio { get; set; }
        public DateTime fecha_fin { get; set; }
        public double precio { get; set; }
        public bool aprobada { get; set; }
    }
}
