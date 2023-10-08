﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly ITourRepository _tourRepository;

        public TourController(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Tour))]
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

            if (!_tourRepository.CreateTour(tour.LocationId, tour))
            {
                ModelState.AddModelError("", "Something went wrong with tour saving");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("PostTour", new { id = tour.Id }, tour);
        }

    }
}
