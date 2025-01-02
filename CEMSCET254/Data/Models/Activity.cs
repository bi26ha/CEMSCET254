namespace CEMSCET254.Data.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Event> Events { get; set; }
    }
}
