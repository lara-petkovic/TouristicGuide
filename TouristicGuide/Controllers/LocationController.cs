using Microsoft.AspNetCore.Mvc;
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
    }
}
