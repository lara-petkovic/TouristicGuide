using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Touristic_App.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public int GuideId {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfGuests { get; set; }
    }
}
