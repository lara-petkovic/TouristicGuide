using TouristicGuide.Data;
using TouristicGuide.Interfaces;
using TouristicGuide.Models;

namespace TouristicGuide.Repository
{
    public class AppointmentCommandsRepository: IAppointmentCommandsRepository
    {
        private readonly DataContext _context;

        public AppointmentCommandsRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public bool CreateAppointment(Appointment appointment)
        {
            _context.Add(appointment);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
