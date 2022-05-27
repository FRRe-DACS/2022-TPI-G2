using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.Repository.Models
{
    public class PackageReservation
    {
        public int PackageId { get; set; }
        public Package Package { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
