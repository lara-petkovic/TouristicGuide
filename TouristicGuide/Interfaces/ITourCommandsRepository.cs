using Touristic_App.Models;

namespace TouristicGuide.Interfaces
{
    public interface ITourCommandsRepository
    {
        public bool CreateTour(int locationId, Tour tour);
        public bool Save();
    }
}
