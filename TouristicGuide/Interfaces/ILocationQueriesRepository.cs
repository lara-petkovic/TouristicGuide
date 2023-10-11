using TouristicGuide.Models;

namespace TouristicGuide.Interfaces
{
    public interface ILocationQueriesRepository
    {
        public ICollection<Location> GetLocations();
        public Location GetLocation(int id);
        public bool LocationExists(int id);
    }
}
