using Touristic_App.Models;

namespace TouristicGuide.Interfaces
{
    public interface ITourRepository
    {
        public ICollection<Tour> GetTours();
        public bool CreateTour (int locationId, Tour tour);
        public bool Save();
    }
}
