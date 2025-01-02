﻿namespace CEMSCET254.Data.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public List<Event> Events { get; set; }
    }
}
