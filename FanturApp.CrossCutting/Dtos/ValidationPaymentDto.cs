using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.CrossCutting.Dtos
{
    public class ValidationPaymentDto
    {
        public int reservationId { get; set; }
        public long cuit { get; set; }
        //public string cardNro { get; set; }
        //public string cardSecurityNro { get; set; }

    }
}
