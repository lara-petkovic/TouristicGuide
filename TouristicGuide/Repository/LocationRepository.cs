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

        public bool CreateLocation(Location location)
        {
            _context.Add(location);
            return Save();
        }

        public ICollection<Location> GetLocations()
        {
            return _context.Locations.OrderBy(l => l.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
