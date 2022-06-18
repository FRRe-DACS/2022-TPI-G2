namespace FanturApp.CrossCutting.Models
{
    public class PackageReservation
    {
        public int PackageId { get; set; }
        public Package Package { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
