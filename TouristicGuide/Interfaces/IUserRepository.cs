using Touristic_App.Models;

namespace TouristicGuide.Interfaces
{
    public interface IUserRepository
    {
        public ICollection<User> GetUsers();
        public User GetUser(int id);
        public User GetUser(string username);
        public bool UserExists(int id);
    }
}
