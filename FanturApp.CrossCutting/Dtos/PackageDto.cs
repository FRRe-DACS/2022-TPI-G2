namespace FanturApp.CrossCutting.Dtos
{
    public class PackageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? PackagePrice { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ValidDate { get; set; }
    }
}
