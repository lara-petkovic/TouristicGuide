using Microsoft.AspNetCore.Mvc;
using Touristic_App.Models;
using TouristicGuide.DTO;
using TouristicGuide.Interfaces;
using TouristicGuide.Models;
using TouristicGuide.Repository;

namespace TouristicGuide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController: Controller
    {
        private readonly ITourQueriesRepository _tourQueriesRepo;
        private readonly ITourCommandsRepository _tourCommandsRepo;

        public TourController(ITourQueriesRepository tourQueriesRepo, ITourCommandsRepository tourCommandsRepo)
        {
            _tourQueriesRepo = tourQueriesRepo;
            _tourCommandsRepo = tourCommandsRepo;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Tour))]
        public IActionResult GetTours()
        {
            var tours = _tourQueriesRepo.GetTours();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tours);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Tour))]
        [ProducesResponseType(400)]
        public IActionResult CreateTour([FromBody] TourDTO tourDTO)
        {
            if (tourDTO == null)
            {
                return BadRequest("Tour object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tour = new Tour
            {
                Id = tourDTO.Id,
                Name = tourDTO.Name,
                Description = tourDTO.Description,
                LocationId = tourDTO.LocationId
            };

            if (!_tourCommandsRepo.CreateTour(tour.LocationId, tour))
            {
                ModelState.AddModelError("", "Something went wrong with tour saving");
                return StatusCode(500, ModelState);
            }

            return Created("", tour);
        }

    }
}
