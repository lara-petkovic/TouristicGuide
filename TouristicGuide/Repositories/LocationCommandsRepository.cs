using TouristicGuide.Data;
using TouristicGuide.Interfaces;
using TouristicGuide.Models;

namespace TouristicGuide.Repository
{
    public class LocationCommandsRepository: ILocationCommandsRepository
    {
        private readonly DataContext _context;
        public LocationCommandsRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateLocation(Location location)
        {
            _context.Add(location);
            return Save();
        }
        public bool UpdateLocation(Location location)
        {
            var locationToUpdate = _context.Locations.FirstOrDefault(item => item.Id == location.Id);

            if (locationToUpdate == null)
            {
                return false;
            }

            locationToUpdate.City = location.City;
            locationToUpdate.Country = location.Country;

            return Save();
        }
        public bool DeleteLocation(int id)
        {
            var locationToDelete = _context.Locations.FirstOrDefault(item => item.Id == id);

            if (locationToDelete == null)
            {
                return false;
            }
            _context.Locations.Remove(locationToDelete);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
