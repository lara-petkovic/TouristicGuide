﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Appointment))]
        [ProducesResponseType(400)]
        public IActionResult GetAppointment(int id)
        {
            if (!_appointmentQueriesRepo.AppointmentExists(id))
            {
                return NotFound();
            }

            var location = _appointmentQueriesRepo.GetAppointment(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(location);
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
            return Created("/api/appointment/" + appointment.Id.ToString(), appointment);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAppointment(int id)
        {
            if (!_appointmentQueriesRepo.AppointmentExists(id))
            {
                return NotFound();
            }

            if (!_appointmentCommandsRepo.DeleteAppointment(id))
            {
                ModelState.AddModelError("", "Something went wrong with appointment deletion");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAppointment(int id, [FromBody] Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest("Appointment object is null");
            }

            if (!_appointmentQueriesRepo.AppointmentExists(id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            appointment.Id = id;

            if (!_appointmentCommandsRepo.UpdateAppointment(appointment))
            {
                ModelState.AddModelError("", "Something went wrong with appointment update");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
