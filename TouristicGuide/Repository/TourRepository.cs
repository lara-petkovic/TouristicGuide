using Touristic_App.Models;
using TouristicGuide.Data;
using TouristicGuide.Interfaces;

namespace TouristicGuide.Repository
{
    public class TourRepository: ITourRepository
    {
        private readonly DataContext _context;

        public TourRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public ICollection<Tour> GetTours()
        {
            return _context.Tours.OrderBy(x => x.Id).ToList();
        }
    }
}
