using Microsoft.AspNetCore.Mvc;
using TouristicGuide.Interfaces;
using TouristicGuide.Models;

namespace TouristicGuide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController: Controller
    {
        private readonly IAppointmentQueriesRepository _appointmentQueriesRepo;
        private readonly IAppointmentCommandsRepository _appointmentCommandsRepo;

        public AppointmentController(IAppointmentQueriesRepository appointmentQueriesRepository, IAppointmentCommandsRepository appointmentCommandsRepository)
        {
            _appointmentQueriesRepo = appointmentQueriesRepository;
            _appointmentCommandsRepo = appointmentCommandsRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Appointment))]
        public IActionResult GetAppointments()
        {
            var appointments = _appointmentQueriesRepo.GetAppointments();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(appointments);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Appointment))]
        public IActionResult PostAppointment(Appointment appointment)
        {
            if(appointment == null)
            {
                return BadRequest("Appointment object is null");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_appointmentCommandsRepo.CreateAppointment(appointment))
            {
                ModelState.AddModelError("", "Something went wrong with appointment saving");
                return StatusCode(500, ModelState);
            }
            return Created("", appointment);
        }
    }
}
