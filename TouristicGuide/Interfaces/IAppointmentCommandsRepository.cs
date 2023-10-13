using TouristicGuide.Models;

namespace TouristicGuide.Interfaces
{
    public interface IAppointmentCommandsRepository
    {
        public bool CreateAppointment(Appointment appointment);
        public bool UpdateAppointment(Appointment appointment);
        public bool DeleteAppointment(int id);
        public bool Save();
    }
}
