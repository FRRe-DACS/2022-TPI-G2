using FanturApp.CrossCutting.Models;

namespace FanturApp.CrossCutting.Dtos
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double ServicePrice { get; set; }
        public ServiceCategory Category { get; set; }
    }
}
