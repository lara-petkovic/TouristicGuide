using Touristic_App.Models;
using TouristicGuide.Models;

namespace TouristicGuide.Interfaces
{
    public interface IUserQueriesRepository
    {
        public ICollection<User> GetUsers();
        public User GetUser(int id);
        public User GetUser(string username);
        public bool UserExists(int id);
    }
}
