using System;

namespace Guide.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
