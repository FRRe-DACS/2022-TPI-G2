using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.Repository.Models
{
    public class PassengerReservation
    {
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

    }
}
