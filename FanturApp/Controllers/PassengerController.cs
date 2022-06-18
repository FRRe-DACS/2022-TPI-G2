using AutoMapper;
using FanturApp.Business.Interfaces;
using FanturApp.CrossCutting.Dtos;
using FanturApp.CrossCutting.Models;
using Microsoft.AspNetCore.Mvc;

namespace FanturApp.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerBusiness _passengerBusiness;
        private readonly IUserBusiness _userBusiness;
        private readonly IMapper _mapper;

        public PassengerController(IPassengerBusiness passengerBusiness, IUserBusiness userBusiness, IMapper mapper)
        {
            _passengerBusiness = passengerBusiness;
            _userBusiness = userBusiness;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Passenger>))]
        public IActionResult GetPassengers()
        {
            var passengers = _mapper.Map<List<PassengerDto>>(_passengerBusiness.GetPassengers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(passengers);
        }

        [HttpGet("{passengerId}")]
        [ProducesResponseType(200, Type = typeof(Passenger))]
        [ProducesResponseType(400)]
        public IActionResult GetPassenger(int passengerId)
        {
            if (!_passengerBusiness.PassengerExists(passengerId))
                return NotFound();

            var passenger = _mapper.Map<PassengerDto>(_passengerBusiness.GetPassenger(passengerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(passenger);
        }


        [HttpGet("{passengerId}/user")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUserByPassenger(int passengerId)
        {
            if (!_passengerBusiness.PassengerExists(passengerId))
                return NotFound();

            var user = _mapper.Map<UserDto>(_passengerBusiness.GetUserByPassenger(passengerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePassenger([FromQuery] int userid, [FromBody] PassengerDto passengerCreate)
        {
            if (passengerCreate == null)
                return BadRequest(ModelState);

            var passenger = _passengerBusiness.GetPassengers()
                .Where(u => u.Dni == passengerCreate.Dni)
                .FirstOrDefault();

            if (passenger != null)
            {
                ModelState.AddModelError("", "Passenger already exist");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var passengerMap = _mapper.Map<Passenger>(passengerCreate);

            passengerMap.User = _userBusiness.GetUser(userid);

            if (!_passengerBusiness.CreatePassenger(passengerMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Passenger successfully created");

        }

        [HttpPut("{passengerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePassenger(int passengerId, [FromBody] PassengerDto updatedPassenger)
        {
            if (updatedPassenger == null)
                return BadRequest(ModelState);

            if (passengerId != updatedPassenger.Id)
                return BadRequest(ModelState);

            if (!_passengerBusiness.PassengerExists(passengerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var passengerMap = _mapper.Map<Passenger>(updatedPassenger);

            if (!_passengerBusiness.UpdatePassenger(passengerMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();



        }

        [HttpDelete("{passengerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeletePassenger(int passengerId)
        {

            if (!_passengerBusiness.PassengerExists(passengerId))
                return NotFound();


            var passengerToDelete = _passengerBusiness.GetPassenger(passengerId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_passengerBusiness.DeletePassenger(passengerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
            }

            return NoContent();

        }
    }
}
