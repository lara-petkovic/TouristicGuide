using Microsoft.AspNetCore.Mvc; //MVC IMPORTANT!
using Touristic_App.Models;
using TouristicGuide.Interfaces;

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
    }
}
