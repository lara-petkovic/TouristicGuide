using TouristicGuide.Models;

namespace TouristicGuide.Interfaces
{
    public interface ILocationCommandsRepository
    {
        public bool CreateLocation(Location location);
        bool Save();
    }
}
