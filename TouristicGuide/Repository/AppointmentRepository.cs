using TouristicGuide.Data;
using TouristicGuide.Interfaces;
using TouristicGuide.Models;

namespace TouristicGuide.Repository
{
    public class AppointmentRepository: IAppointmentRepository
    {
        private readonly DataContext _context;

        public AppointmentRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public ICollection<Appointment> GetAppointments()
        {
            return _context.Appointments.OrderBy(a => a.Id).ToList();
        }
    }
}
