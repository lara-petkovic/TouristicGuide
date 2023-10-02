using Microsoft.AspNetCore.Mvc;
using TouristicGuide.Interfaces;
using TouristicGuide.Models;

namespace TouristicGuide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController: Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Appointment>))]
        public IActionResult GetAppointments()
        {
            var appointments = _appointmentRepository.GetAppointments();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(appointments);
        }
    }
}
