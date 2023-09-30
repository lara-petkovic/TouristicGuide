using System.Collections.ObjectModel;
using TouristicGuide.Models;

namespace Touristic_App.Models
{
    public class User
    {
        public long Id { get; set; }
        public String Username { get; set; }
        public string Password { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public Collection<Appointment> Appointments { get; set; }
    }
}
