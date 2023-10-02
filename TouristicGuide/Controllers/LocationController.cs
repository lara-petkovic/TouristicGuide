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
        [ProducesResponseType(200, Type = typeof(IEnumerable<Location>))]
        public IActionResult GetLocations()
        {
            var locations = _locationRepository.GetLocations();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(locations);
        }
    }
}
