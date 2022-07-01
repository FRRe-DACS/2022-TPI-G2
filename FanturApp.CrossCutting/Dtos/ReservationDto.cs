namespace FanturApp.CrossCutting.Dtos
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ValidDate { get; set; }
        public string Status { get; set; }
    }
}
