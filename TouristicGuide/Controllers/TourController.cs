using Microsoft.AspNetCore.Mvc;
using Touristic_App.Models;
using TouristicGuide.Interfaces;
using TouristicGuide.Models;
using TouristicGuide.Repository;

namespace TouristicGuide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController: Controller
    {
        private readonly ITourRepository _tourRepository;

        public TourController(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Tour>))]
        public IActionResult GetTours()
        {
            var tours = _tourRepository.GetTours();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tours);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public IActionResult CreateTour([FromQuery] int locationId, [FromBody] Tour tour) //If I have arguments, i would get them with -> FromQuery
        {
            if (tour == null)
            {
                return BadRequest("Location object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_tourRepository.CreateTour(locationId, tour))
            {
                ModelState.AddModelError("", "Something went wrong with tour saving");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetTour", new { id = tour.Id }, tour);
        }
    }
}
