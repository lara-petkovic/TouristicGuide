﻿using System.Collections.ObjectModel;
using TouristicGuide.Models;

namespace Touristic_App.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
