namespace CEMSCET254.Data.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Registration> Registrations { get; set; }
    }
}
