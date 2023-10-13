using Touristic_App.Models;

namespace TouristicGuide.Interfaces
{
    public interface IUserCommandsRepository
    {
        public bool CreateUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(int id);
        public bool Save();
    }
}
