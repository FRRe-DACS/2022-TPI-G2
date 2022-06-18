namespace FanturApp.CrossCutting.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public Reservation Reservation { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
