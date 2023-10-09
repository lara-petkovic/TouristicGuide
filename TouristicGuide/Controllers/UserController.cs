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
        private readonly IUserQueriesRepository _userQueriesRepo;
        private readonly IUserCommandsRepository _userCommandsRepo;

        public UserController(IUserQueriesRepository userQueriesRepo, IUserCommandsRepository userCommandsRepo)
        {
            _userQueriesRepo = userQueriesRepo;
            _userCommandsRepo = userCommandsRepo;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        { 
            var users = _userQueriesRepo.GetUsers();
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
            if(!_userQueriesRepo.UserExists(id))
            {
                return NotFound();
            }

            var user = _userQueriesRepo.GetUser(id);
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

            if (!_userCommandsRepo.CreateUser(user))
            {
                ModelState.AddModelError("", "Something went wrong with user saving");
                return StatusCode(500, ModelState);
            }

            return Created("", user);
        }
    }
}
