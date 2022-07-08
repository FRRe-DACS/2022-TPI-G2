using FanturApp.Business.Interfaces;
using FanturApp.CrossCutting.Dtos;
using FanturApp.CrossCutting.Helpers;
using FanturApp.CrossCutting.Models;
using FanturApp.DataAccess.Context;
using FanturApp.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FanturApp.Business.Implementations
{
    public class ValidationBusiness : IValidationBusiness
    {
        private readonly IPaymentDataAccess _paymentDataAccess;
        private readonly IReservationDataAccess _reservationDataAccess;
        private readonly DataContext _context;

        public ValidationBusiness(IPaymentDataAccess paymentDataAccess, IReservationDataAccess reservationDataAccess, DataContext context)
        {
            _paymentDataAccess = paymentDataAccess;
            _reservationDataAccess = reservationDataAccess;
            _context = context;
        }
        public async Task<ValidationResultDto> ValidateReservation(ValidationDto validation, Reservation reservation)
        {
            string url = "http://localhost:8080/operacion";

            var data = JsonSerializer.Serialize<ValidationDto>(validation);

            HttpContent content = 
                new StringContent(data, Encoding.UTF8, "application/json");

            content.Headers.ContentType.CharSet = "";

            var httpResponse = await ValidationApi.ApiClient.PostAsync(url, content);


            //using (HttpResponseMessage response = await ValidationApi.ApiClient.PostAsync(url, content))
            //{
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();

                    var validationVeredict = JsonSerializer.Deserialize<ValidationResultDto>(result);

                    if (validationVeredict.aprobada)
                    {
                        var newPayment = new Payment()
                        {
                        PaymentDate = DateTime.Now,
                        PaymentMethod = _paymentDataAccess.GetPaymentMethod(1),
                        Reservation = reservation,
                        };

                        reservation.Status = "Pagada";
                        _context.Update(reservation);
                    _reservationDataAccess.Save();

                    _paymentDataAccess.CreatePayment(newPayment);

                    }



                    return validationVeredict;
                }
                else
                {
                    throw new Exception(httpResponse.ReasonPhrase);
                }
            //}


            //using (HttpResponseMessage response = await ValidationApi.ApiClient.GetAsync(url))
            //{
            //    if (response.IsSuccessStatusCode)
            //    {
            //        ValidationResultDto result = 
            //            await response.Content.ReadAsAsync<ValidationResultDto>();

                //        return result;
                //    }
                //    else
                //    {
                //        throw new Exception(response.ReasonPhrase);
                //    }
                //}

        }
    }
}
