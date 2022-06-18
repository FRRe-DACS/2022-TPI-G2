namespace FanturApp.CrossCutting.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double ServicePrice { get; set; }
        public ServiceCategory Category { get; set; }
        public ICollection<PackageService> PackageServices { get; set; }
    }
}
