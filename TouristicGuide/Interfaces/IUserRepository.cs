using Touristic_App.Models;

namespace TouristicGuide.Interfaces
{
    public interface IUserRepository
    {
        public ICollection<User> GetUsers();
    }
}
