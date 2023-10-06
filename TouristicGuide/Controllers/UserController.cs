using Microsoft.AspNetCore.Mvc; //MVC IMPORTANT!
using Touristic_App.Models;
using TouristicGuide.DTO;
using TouristicGuide.Interfaces;
using TouristicGuide.Models;
using TouristicGuide.Repository;

namespace TouristicGuide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        { 
            var users = _userRepository.GetUsers();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int id)
        {
            if(!_userRepository.UserExists(id))
            {
                return NotFound();
            }

            var user = _userRepository.GetUser(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult CreateTour([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_userRepository.CreateUser(user))
            {
                ModelState.AddModelError("", "Something went wrong with user saving");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("PostUser", new { id = user.Id }, user);
        }
    }
}
