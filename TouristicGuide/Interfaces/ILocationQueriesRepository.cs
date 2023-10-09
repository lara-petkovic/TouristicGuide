using TouristicGuide.Models;

namespace TouristicGuide.Interfaces
{
    public interface ILocationQueriesRepository
    {
        public ICollection<Location> GetLocations();
    }
}
