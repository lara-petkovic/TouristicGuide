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
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
