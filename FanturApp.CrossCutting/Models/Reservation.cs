namespace FanturApp.CrossCutting.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public User User { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ValidDate { get; set; }
        public string Status { get; set; }
        public ICollection<PackageReservation> PackageReservations { get; set; }
        public ICollection<PassengerReservation> PassengerReservations { get; set; }
    }
}
