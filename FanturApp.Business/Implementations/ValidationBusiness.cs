using FanturApp.Business.Interfaces;
using FanturApp.CrossCutting.Dtos;
using FanturApp.CrossCutting.Helpers;
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
        public async Task<ValidationResultDto> ValidateReservation(ValidationDto validation)
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
