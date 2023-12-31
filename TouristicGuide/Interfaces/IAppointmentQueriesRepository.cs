﻿using TouristicGuide.Models;

namespace TouristicGuide.Interfaces
{
    public interface IAppointmentQueriesRepository
    {
        public ICollection<Appointment> GetAppointments();
        public Appointment GetAppointment(int id);
        public ICollection<Appointment> GetAppointmentsByUser(int userId);
        public bool AppointmentExists(int id);
    }
}
