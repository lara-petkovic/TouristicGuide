using Touristic_App.Models;
using TouristicGuide.Data;
using TouristicGuide.Interfaces;

namespace TouristicGuide.Repository
{
    public class TourCommandsRepository: ITourCommandsRepository
    {
        private readonly DataContext _context;

        public TourCommandsRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public bool CreateTour(int locationId, Tour tour)
        {
            var location = _context.Locations.FirstOrDefault(x => x.Id == locationId);
            if (location == null)
                return false;
            tour.Location = location; //do i need this?
            _context.Add(tour);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
