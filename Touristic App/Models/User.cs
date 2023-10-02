using System.Collections.ObjectModel;

namespace Touristic_App.Models
{
    public class User
    {
        public long Id { get; set; }
        public String Username { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public Collection<Tour> Tours { get; set; }
    }
}
