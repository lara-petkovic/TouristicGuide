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
        public bool UpdateAppointment(Appointment appointment)
        {
            var appoitnmentToUpdate = _context.Appointments.FirstOrDefault(item => item.Id == appointment.Id);

            if (appoitnmentToUpdate == null)
            {
                return false;
            }

            appoitnmentToUpdate.TourId = appointment.TourId;
            appoitnmentToUpdate.Tour = appointment.Tour;
            appoitnmentToUpdate.UserId = appointment.UserId;
            appoitnmentToUpdate.DateTime = appointment.DateTime;

            return Save();
        }
        public bool DeleteAppointment(int id)
        {
            var appointmentToDelete = _context.Appointments.FirstOrDefault(item => item.Id == id);

            if (appointmentToDelete == null)
            {
                return false;
            }
            _context.Appointments.Remove(appointmentToDelete);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
