﻿using Microsoft.AspNetCore.Mvc;
using Touristic_App.Models;
using TouristicGuide.Interfaces;
using TouristicGuide.Models;

namespace TouristicGuide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController: Controller
    {
        private readonly ILocationQueriesRepository _locationQueriesRepo;
        private readonly ILocationCommandsRepository _locationCommandsRepo;

        public LocationController(ILocationQueriesRepository locationQueriesRepo, ILocationCommandsRepository locationCommandsRepo)
        {
            _locationQueriesRepo = locationQueriesRepo;
            _locationCommandsRepo = locationCommandsRepo;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Location))]
        public IActionResult GetLocations()
        {
            var locations = _locationQueriesRepo.GetLocations();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(locations);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public IActionResult GetLocation(int id)
        {
            if (!_locationQueriesRepo.LocationExists(id))
            {
                return NotFound();
            }

            var location = _locationQueriesRepo.GetLocation(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(location);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public IActionResult CreateLocation([FromBody] Location location)
        {
            if (location == null)
            {
                return BadRequest("Location object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_locationCommandsRepo.CreateLocation(location))
            {
                ModelState.AddModelError("", "Something went wrong with location saving");
                return StatusCode(500, ModelState);
            }

            return Created("/api/location/" + location.Id.ToString(), location);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteLocation(int id)
        {
            if (!_locationQueriesRepo.LocationExists(id))
            {
                return NotFound();
            }

            if (!_locationCommandsRepo.DeleteLocation(id))
            {
                ModelState.AddModelError("", "Something went wrong with location deletion");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateLocation(int id, [FromBody] Location location)
        {
            if (location == null)
            {
                return BadRequest("Location object is null");
            }

            if (!_locationQueriesRepo.LocationExists(id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            location.Id = id;

            if (!_locationCommandsRepo.UpdateLocation(location))
            {
                ModelState.AddModelError("", "Something went wrong with location update");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
