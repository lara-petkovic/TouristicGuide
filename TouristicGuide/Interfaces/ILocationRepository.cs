using TouristicGuide.Models;

namespace TouristicGuide.Interfaces
{
    public interface ILocationRepository
    {
        public ICollection<Location> GetLocations();
    }
}
