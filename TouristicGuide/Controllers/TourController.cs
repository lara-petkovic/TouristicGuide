using Microsoft.AspNetCore.Mvc;
using Touristic_App.Models;
using TouristicGuide.Interfaces;

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
    }
}
