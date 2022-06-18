namespace FanturApp.CrossCutting.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? PackagePrice { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ValidDate { get; set; }
        public ICollection<PackageService> PackageServices { get; set; }
        public ICollection<PackageReservation> PackageReservations { get; set; }
    }
}
