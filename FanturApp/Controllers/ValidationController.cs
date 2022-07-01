using FanturApp.Business.Interfaces;
using FanturApp.CrossCutting.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FanturApp.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        private readonly IValidationBusiness _validationBusiness;
        private readonly IReservationBusiness _reservationBusiness;

        public ValidationController(IValidationBusiness validationBusiness, IReservationBusiness reservationBusiness)
        {
            _validationBusiness = validationBusiness;
            _reservationBusiness = reservationBusiness;
        }



       [HttpPost]
        public Task<ValidationResultDto> PostValidation(int reservationId)
        {

            var reservation = _reservationBusiness.GetReservation(reservationId);

            ValidationDto validation = new ValidationDto()
            {
                cuit = 1214214,
                fecha_incio = reservation.CreateDate.ToString("yyyy-MM-dd'T'HH:mm:ssZ"),
                fecha_fin = reservation.ValidDate.ToString("yyyy-MM-dd'T'HH:mm:ssZ"),
                precio = (double)reservation.TotalPrice,

            };
           

            //agregar elegancia al catch y parametros al metodo
            try
            {
                return _validationBusiness.ValidateReservation(validation);
            }
            catch (Exception)
            {

                throw;
            }

            
        }





    }
}
