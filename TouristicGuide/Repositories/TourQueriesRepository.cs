using Touristic_App.Models;
using TouristicGuide.Data;
using TouristicGuide.Interfaces;

namespace TouristicGuide.Repository
{
    public class TourQueriesRepository: ITourQueriesRepository
    {
        private readonly DataContext _context;

        public TourQueriesRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public Tour GetTour(int id)
        {
            return _context.Tours.FirstOrDefault(t => t.Id == id);
        }

        public ICollection<Tour> GetTours()
        {
            return _context.Tours.OrderBy(x => x.Id).ToList();
        }

        public bool TourExists(int id)
        {
            return _context.Tours.Any(t => t.Id == id);
        }
    }
}
