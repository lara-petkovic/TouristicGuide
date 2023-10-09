using Touristic_App.Models;

namespace TouristicGuide.Interfaces
{
    public interface IUserCommandsRepository
    {
        public bool CreateUser(User user);
        public bool Save();
    }
}
