using TouristicGuide.Models;

namespace TouristicGuide.Interfaces
{
    public interface ILocationCommandsRepository
    {
        public bool CreateLocation(Location location);
        public bool DeleteLocation(int id);
        public bool UpdateLocation(Location location);
        bool Save();
    }
}
