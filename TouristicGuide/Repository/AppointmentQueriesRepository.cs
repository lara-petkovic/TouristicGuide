using TouristicGuide.Data;
using TouristicGuide.Interfaces;
using TouristicGuide.Models;

namespace TouristicGuide.Repository
{
    public class AppointmentQueriesRepository: IAppointmentQueriesRepository
    {
        private readonly DataContext _context;

        public AppointmentQueriesRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(x => x.Id == id);
        }

        public Appointment GetAppointment(int id)
        {
            return _context.Appointments.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Appointment> GetAppointmentsByUser(int userId)
        {
            return _context.Appointments.Where(x => x.Id == userId).ToList();
        }

        public ICollection<Appointment> GetAppointments()
        {
            return _context.Appointments.OrderBy(a => a.Id).ToList();
        }
    }
}
