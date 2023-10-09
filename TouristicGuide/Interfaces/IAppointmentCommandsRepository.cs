using TouristicGuide.Models;

namespace TouristicGuide.Interfaces
{
    public interface IAppointmentCommandsRepository
    {
        public bool CreateAppointment(Appointment appointment);
        public bool Save();
    }
}
