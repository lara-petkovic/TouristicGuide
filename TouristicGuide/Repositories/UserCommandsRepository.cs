using Touristic_App.Models;
using TouristicGuide.Data;
using TouristicGuide.Interfaces;

namespace TouristicGuide.Repository
{
    public class UserCommandsRepository: IUserCommandsRepository
    {
        private readonly DataContext _context;

        public UserCommandsRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public bool CreateUser(User user)
        {
            _context.Add(user);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
