using TouristicGuide.Data;
using TouristicGuide.Interfaces;
using TouristicGuide.Models;

namespace TouristicGuide.Repository
{
    public class LocationRepository: ILocationRepository
    {
        private readonly DataContext _context;

        public LocationRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public ICollection<Location> GetLocations()
        {
            return _context.Locations.OrderBy(l => l.Id).ToList();
        }
    }
}
