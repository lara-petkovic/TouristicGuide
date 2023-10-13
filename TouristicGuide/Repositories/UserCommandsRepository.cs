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
        public bool UpdateUser(User user)
        {
            var userToUpdate = _context.Users.FirstOrDefault(i => i.Id == user.Id);
            if (userToUpdate == null)
            {
                return false;
            }

            userToUpdate.Appointments = user.Appointments;
            userToUpdate.Username = user.Username;
            userToUpdate.Password = user.Password;
            userToUpdate.Name = user.Name;
            userToUpdate.Surname = user.Surname;

            return Save();
        }
        public bool DeleteUser(int id)
        {
            var userToDelete = _context.Users.FirstOrDefault(i => i.Id == id);
            if (userToDelete == null)
            {
                return false;
            }
            _context.Users.Remove(userToDelete);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
