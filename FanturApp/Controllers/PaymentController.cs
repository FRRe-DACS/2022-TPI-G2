using AutoMapper;
using FanturApp.Business.Interfaces;
using FanturApp.Repository.Dtos;
using FanturApp.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FanturApp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentBusiness _paymentBusiness;
        private readonly IReservationBusiness _reservationBusiness;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentBusiness paymentBusiness,IReservationBusiness reservationBusiness, IMapper mapper)
        {
            _paymentBusiness = paymentBusiness;
            _reservationBusiness = reservationBusiness;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Payment>))]
        public IActionResult GetPayments()
        {
            var payments = _mapper.Map<List<PaymentDto>>(_paymentBusiness.GetPayments());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(payments);
        }

        [HttpGet("{paymentId}")]
        [ProducesResponseType(200, Type = typeof(Payment))]
        [ProducesResponseType(400)]
        public IActionResult GetPayment(int paymentId)
        {
            if (!_paymentBusiness.PaymentExists(paymentId))
                return NotFound();

            var payment = _mapper.Map<PaymentDto>(_paymentBusiness.GetPayment(paymentId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(payment);
        }


        [HttpGet("{paymentId}/reservation")]
        [ProducesResponseType(200, Type = typeof(Reservation))]
        [ProducesResponseType(400)]
        public IActionResult GetReservationByPayment(int paymentId)
        {
            if (!_paymentBusiness.PaymentExists(paymentId))
                return NotFound();

            var reservation = _mapper.Map<ReservationDto>(_paymentBusiness.GetReservationByPayment(paymentId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(reservation);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePayment([FromQuery] int reservationId, [FromQuery] int paymentmethodid, [FromBody] PaymentDto paymentCreate)
        {
            if (paymentCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymentMap = _mapper.Map<Payment>(paymentCreate);

            paymentMap.Reservation = _reservationBusiness.GetReservation(reservationId);
            paymentMap.PaymentMethod = _paymentBusiness.GetPaymentMethod(paymentmethodid);

            if (!_paymentBusiness.CreatePayment(paymentMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Payment successfully created");

        }

        [HttpPut("{paymentId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePayment(int paymentId, [FromBody] PaymentDto updatedPayment)
        {
            if (updatedPayment == null)
                return BadRequest(ModelState);

            if (paymentId != updatedPayment.Id)
                return BadRequest(ModelState);

            if (!_paymentBusiness.PaymentExists(paymentId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var paymentMap = _mapper.Map<Payment>(updatedPayment);

            if (!_paymentBusiness.UpdatePayment(paymentMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{paymentId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeletePayment(int paymentId)
        {

            if (!_paymentBusiness.PaymentExists(paymentId))
                return NotFound();


            var paymentToDelete = _paymentBusiness.GetPayment(paymentId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_paymentBusiness.DeletePayment(paymentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
            }

            return NoContent();

        }
    }
}
