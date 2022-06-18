using AutoMapper;
using FanturApp.Business.Interfaces;
using FanturApp.CrossCutting.Dtos;
using FanturApp.CrossCutting.Models;
using Microsoft.AspNetCore.Mvc;

namespace FanturApp.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationBusiness _reservationBusiness;
        private readonly IUserBusiness _userBusiness;
        private readonly IMapper _mapper;

        public ReservationController(IReservationBusiness reservationBusiness, IUserBusiness userbusiness, IMapper mapper)
        {
            _reservationBusiness = reservationBusiness;
            _userBusiness = userbusiness;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reservation>))]
        public IActionResult GetReservations()
        {
            var reservations = _mapper.Map<List<ReservationDto>>(_reservationBusiness.GetReservations());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reservations);
        }

        [HttpGet("{reservationId}")]
        [ProducesResponseType(200, Type = typeof(Reservation))]
        [ProducesResponseType(400)]
        public IActionResult GetReservation(int reservationId)
        {
            if (!_reservationBusiness.ReservationExists(reservationId))
                return NotFound();

            var reservation = _mapper.Map<ReservationDto>(_reservationBusiness.GetReservation(reservationId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(reservation);
        }

        [HttpGet("By/{status}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reservation>))]
        public IActionResult GetReservationsByStatus(string status)
        {
            var reservations = _mapper.Map<List<ReservationDto>>(_reservationBusiness.GetReservationsByStatus(status));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reservations);
        }

        [HttpGet("{reservationId}/user")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUserByReservation(int reservationId)
        {
            if (!_reservationBusiness.ReservationExists(reservationId))
                return NotFound();

            var user = _mapper.Map<UserDto>(_reservationBusiness.GetUserByReservation(reservationId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(user);
        }

        [HttpGet("{reservationId}/packages")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Package>))]
        [ProducesResponseType(400)]
        public IActionResult GetPackagesByReservation(int reservationId)
        {
            if (!_reservationBusiness.ReservationExists(reservationId))
                return NotFound();

            var packages = _mapper.Map<List<PackageDto>>(_reservationBusiness.GetPackagesByReservation(reservationId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(packages);
        }

        [HttpGet("{reservationId}/passengers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Passenger>))]
        [ProducesResponseType(400)]
        public IActionResult GetPassengersByReservation(int reservationId)
        {
            if (!_reservationBusiness.ReservationExists(reservationId))
                return NotFound();

            var passengers = _mapper.Map<List<PassengerDto>>(_reservationBusiness.GetPassengersByReservation(reservationId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(passengers);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReservation([FromQuery] int userid, [FromQuery] int packageid, [FromQuery] List<int> passengerid, [FromBody] ReservationDto reservationCreate)
        {
            if (reservationCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reservationMap = _mapper.Map<Reservation>(reservationCreate);

            reservationMap.User = _userBusiness.GetUser(userid);



            if (!_reservationBusiness.CreateReservation(passengerid, packageid, reservationMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Reservation successfully created");

        }

        [HttpPut("{reservationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateReservation(int reservationId, [FromQuery] int passengerId, [FromQuery] List<int> packageId, [FromBody] ReservationDto updatedReservation)
        {
            if (updatedReservation == null)
                return BadRequest(ModelState);

            if (reservationId != updatedReservation.Id)
                return BadRequest(ModelState);

            if (!_reservationBusiness.ReservationExists(reservationId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var reservationMap = _mapper.Map<Reservation>(updatedReservation);

            if (!_reservationBusiness.UpdateReservation(passengerId, packageId, reservationMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();



        }
    }
}
