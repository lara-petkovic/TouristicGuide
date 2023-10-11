using TouristicGuide.Data;
using TouristicGuide.Interfaces;
using TouristicGuide.Models;

namespace TouristicGuide.Repository
{
    public class LocationQueriesRepository: ILocationQueriesRepository
    {
        private readonly DataContext _context;
        public LocationQueriesRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public ICollection<Location> GetLocations()
        {
            return _context.Locations.OrderBy(l => l.Id).ToList();
        }
        public Location GetLocation(int id)
        {
            return _context.Locations.FirstOrDefault(l => l.Id == id);
        }
        public bool LocationExists(int id)
        {
            return _context.Locations.Any(l => l.Id == id);
        }
    }
}
