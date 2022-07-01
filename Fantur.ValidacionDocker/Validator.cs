using FanturApp.CrossCutting.Dtos;
using Newtonsoft.Json;
using System;

namespace Fantur.ValidacionDocker
{
    class Validator
    {

        static async Task Main(string[] args)
        {

            string url = "http://localhost:8080/operacion";

            var client = new HttpClient();

            DockerBody dockerBody = new DockerBody()
            {
                cuit = 20284435215,
                fecha_incio = "2022-04-23T11:11:43.7635-03:00",
                fecha_fin = "2022-04-23T11:11:43.7635-03:00",
                precio = 10000
            };

            var data = JsonConvert.SerializeObject(dockerBody);
            HttpContent content =
                new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await client.PostAsync(url, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                
            }

           
        }










    }


}