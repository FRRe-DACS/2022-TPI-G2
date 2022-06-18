namespace FanturApp.CrossCutting.Dtos
{
    public class PassengerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Dni { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}
