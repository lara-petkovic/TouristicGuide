using TouristicGuide.Models;

namespace TouristicGuide.Interfaces
{
    public interface ILocationRepository
    {
        public ICollection<Location> GetLocations();
        public bool CreateLocation(Location location);
        bool Save();
    }
}
