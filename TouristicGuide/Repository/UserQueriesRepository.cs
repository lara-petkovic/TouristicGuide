using Touristic_App.Models;
using TouristicGuide.Data;
using TouristicGuide.Interfaces;

namespace TouristicGuide.Repository
{
    public class UserQueriesRepository: IUserQueriesRepository
    {
        private readonly DataContext _context;
        public UserQueriesRepository(DataContext context)
        { 
            _context = context;
        }
        public User GetUser(int id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }
        public User GetUser(string username)
        {
            return _context.Users.Where(x => x.Username.Equals(username)).FirstOrDefault();
        }
        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(x => x.Id).ToList();
        }
        public bool UserExists(int id)
        {
            return _context.Users.Any(x => x.Id == id);
        }
    }
}
