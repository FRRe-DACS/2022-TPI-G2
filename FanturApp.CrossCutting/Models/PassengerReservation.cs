namespace FanturApp.CrossCutting.Models
{
    public class PassengerReservation
    {
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

    }
}
