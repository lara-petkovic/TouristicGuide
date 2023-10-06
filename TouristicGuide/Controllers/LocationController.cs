using Microsoft.AspNetCore.Mvc;
using TouristicGuide.Interfaces;
using TouristicGuide.Models;

namespace TouristicGuide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController: Controller
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Location))]
        public IActionResult GetLocations()
        {
            var locations = _locationRepository.GetLocations();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(locations);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public IActionResult CreateLocation([FromBody] Location location) //If I have arguments, i would get them with -> FromQuery
        {
            if (location == null)
            {
                return BadRequest("Location object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_locationRepository.CreateLocation(location))
            {
                ModelState.AddModelError("", "Something went wrong with location saving");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetLocation", new { id = location.Id }, location);
        }
    }
}
