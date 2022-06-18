using AutoMapper;
using FanturApp.Business.Interfaces;
using FanturApp.CrossCutting.Dtos;
using FanturApp.CrossCutting.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FanturApp.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IMapper _mapper;

        public UserController(IUserBusiness userBusiness, IMapper mapper)
        {
            _userBusiness = userBusiness;
            _mapper = mapper;
        }

        // codigo roba2

        [HttpGet("Admins")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hi {currentUser.FirstName}, you are an {currentUser.Role}");
        }


        [HttpGet("Customers")]
        [Authorize(Roles = "Customer")]
        public IActionResult SellersEndpoint()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hi {currentUser.FirstName}, you are a {currentUser.Role}");
        }

        [HttpGet("AdminsAndSellers")]
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult AdminsAndSellersEndpoint()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hi {currentUser.FirstName}, you are an {currentUser.Role}");
        }

        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hi, you're on public property");
        }

        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new User
                {
                    UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    FirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    LastName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }



        // codigo roba2

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userBusiness.GetUsers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(users);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int userId)
        {
            if (!_userBusiness.UserExists(userId))
                return NotFound();

            var user = _mapper.Map<UserDto>(_userBusiness.GetUser(userId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(user);
        }

        [HttpGet("{userId}/passengers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Passenger>))]
        [ProducesResponseType(400)]
        public IActionResult GetPassengersByUser(int userId)
        {
            if (!_userBusiness.UserExists(userId))
                return NotFound();

            var passengers = _mapper.Map<List<PassengerDto>>(_userBusiness.GetPassengersByUser(userId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(passengers);
        }

        [HttpGet("{userId}/reservations")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reservation>))]
        [ProducesResponseType(400)]
        public IActionResult GetReservationsByUser(int userId)
        {
            if (!_userBusiness.UserExists(userId))
                return NotFound();

            var reservations = _mapper.Map<List<ReservationDto>>(_userBusiness.GetReservationsByUser(userId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(reservations);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserDto userCreate)
        {
            if (userCreate == null)
                return BadRequest(ModelState);

            var user = _userBusiness.GetUsers()
                .Where(u => u.UserName.Trim().ToUpper() == userCreate.UserName.Trim().ToUpper())
                .FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", "Username taken");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(userCreate);

            if (!_userBusiness.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("User Successfully created");

        }

        [HttpPut("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(int userId, [FromBody] UserDto updatedUser)
        {
            if (updatedUser == null)
                return BadRequest(ModelState);

            if (userId != updatedUser.Id)
                return BadRequest(ModelState);

            if (!_userBusiness.UserExists(userId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var userMap = _mapper.Map<User>(updatedUser);

            if (!_userBusiness.UpdateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();



        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteService(int userId)
        {

            if (!_userBusiness.UserExists(userId))
                return NotFound();


            var userToDelete = _userBusiness.GetUser(userId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_userBusiness.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
            }

            return NoContent();

        }
    }
}
