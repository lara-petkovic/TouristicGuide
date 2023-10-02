using TouristicGuide.Models;

namespace TouristicGuide.Interfaces
{
    public interface IAppointmentRepository
    {
        public ICollection<Appointment> GetAppointments();
    }
}
