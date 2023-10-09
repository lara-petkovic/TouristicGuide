using Touristic_App.Models;

namespace TouristicGuide.Interfaces
{
    public interface ITourQueriesRepository
    {
        public ICollection<Tour> GetTours();
    }
}
