using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.CrossCutting.Dtos
{
    public class ValidationDto
    {
        public long cuit { get; set; }
        public string fecha_incio { get; set; }
        public string fecha_fin { get; set; }
        public double precio { get; set; }

    }
}
