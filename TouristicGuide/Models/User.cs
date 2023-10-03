using System.Collections.ObjectModel;
using TouristicGuide.Models;

namespace Touristic_App.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public string Password { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
