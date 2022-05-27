using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.Repository.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Dni { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public User User { get; set; }
        public ICollection<PassengerReservation> PassengerReservations { get; set; }
    }
}
