namespace sacco.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
        public string District { get; set; }
        public string Village { get; set; }
        public string Contact { get; set; }
        public string NextOfKin { get; set; }
        public string ContactNextOfKin { get; set; }
        public string Gender { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public string Role { get; set; } = "member";
        public string Status { get; set; } = "approved";








    }
}
