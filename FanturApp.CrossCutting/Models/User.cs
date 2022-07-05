﻿namespace FanturApp.CrossCutting.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public bool? EmailSubscription { get; set; }
        public ICollection<Passenger> Passengers { get; set; }

    }
}
