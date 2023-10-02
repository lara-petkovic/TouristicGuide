using Touristic_App.Models;

namespace TouristicGuide.Interfaces
{
    public interface ITourRepository
    {
        public ICollection<Tour> GetTours();
    }
}
