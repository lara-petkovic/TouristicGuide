using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Touristic_App.Models
{
    public class Guest
    {
        [Required]
        public int Id { get; set; }
        public Collection<Tour> Tours { get; set; }
        public String Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
