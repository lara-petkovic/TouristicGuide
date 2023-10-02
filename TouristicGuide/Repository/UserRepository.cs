using Touristic_App.Models;
using TouristicGuide.Data;
using TouristicGuide.Interfaces;

namespace TouristicGuide.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        { 
            _context = context;
        }
        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(x => x.Id).ToList();
        }
    }
}
