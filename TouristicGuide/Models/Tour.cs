using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TouristicGuide.Models;

namespace Touristic_App.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        //public Location Location { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
