using Touristic_App.Models;

namespace TouristicGuide.Interfaces
{
    public interface ITourQueriesRepository
    {
        public ICollection<Tour> GetTours();
        public bool TourExists(int id);
        public Tour GetTour(int id);
    }
}
