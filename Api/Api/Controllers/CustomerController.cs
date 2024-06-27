using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;

namespace Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        string url = "https://examentecnico.azurewebsites.net/v3/api/Test/Customer";
 
        

        [HttpGet]
        [Route("getCustomer")]

        public async Task<ActionResult<Servicio>> GetCustomer()
        {

           

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Device", "POSTMAN");
                client.DefaultRequestHeaders.Add("Version", "2.0.6.0");
                client.DefaultRequestHeaders.Add("Authorization", "Basic Y2hyaXN0b3BoZXJAZGV2ZWxvcC5teDpUZXN0aW5nRGV2ZWxvcDEyM0AuLi4=");


                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {

                    var responseContent = await response.Content.ReadAsStringAsync();
                    
                    string jsonString = JsonConvert.DeserializeObject<string>(responseContent);
                    var res = JsonConvert.DeserializeObject<string>(jsonString);

                    Servicio resultado = JsonConvert.DeserializeObject<Servicio>(res);

                    return Ok( resultado );
                   

                }
                else
                {
                    return BadRequest();
                }

            }
        }



        [HttpGet]
        [Route("orderAddresses")]
        public async Task<ActionResult<Servicio>> orderAddresses( string field , String order )
        {


            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Device", "POSTMAN");
                client.DefaultRequestHeaders.Add("Version", "2.0.6.0");
                client.DefaultRequestHeaders.Add("Authorization", "Basic Y2hyaXN0b3BoZXJAZGV2ZWxvcC5teDpUZXN0aW5nRGV2ZWxvcDEyM0AuLi4=");


                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                 

                    var responseContent = await response.Content.ReadAsStringAsync();

                    string jsonString = JsonConvert.DeserializeObject<string>(responseContent);
                    var res = JsonConvert.DeserializeObject<string>(jsonString);

                    Servicio resultado = JsonConvert.DeserializeObject<Servicio>(res);

                    var addresses = resultado.addresses;

                    var ord = from Address in addresses
                                  orderby Address.address1 
                                  select Address;

                    if (field == "address1" && order == "descending")
                    {
                        ord = from Address in addresses
                              orderby Address.address1 descending
                              select Address;
                    }else if ( field == "creationDate" && order == "descending")
                    {
                            ord = from Address in addresses
                                  orderby Address.creationDate descending
                                  select Address;
                    }
                    else if ( field == "creationDate" && order == "ascending")
                    {
                        ord = from Address in addresses
                              orderby Address.creationDate 
                              select Address;
                    } 


                    return Ok(ord);


                }
                else
                {
                    return BadRequest();
                }

            }
        }

        [HttpGet]
        [Route("preferredAddress")]
        public async Task<ActionResult<Servicio>> preferredAddress()
        {


            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Device", "POSTMAN");
                client.DefaultRequestHeaders.Add("Version", "2.0.6.0");
                client.DefaultRequestHeaders.Add("Authorization", "Basic Y2hyaXN0b3BoZXJAZGV2ZWxvcC5teDpUZXN0aW5nRGV2ZWxvcDEyM0AuLi4=");


                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {


                    var responseContent = await response.Content.ReadAsStringAsync();

                    string jsonString = JsonConvert.DeserializeObject<string>(responseContent);
                    var res = JsonConvert.DeserializeObject<string>(jsonString);

                    Servicio resultado = JsonConvert.DeserializeObject<Servicio>(res);

                    var addresses = resultado.addresses;

                    var ord = from Address in addresses
                              where Address.preferred == true
                              select Address;

                  


                    return Ok(ord);


                }
                else
                {
                    return BadRequest();
                }

            }
        }


        [HttpGet]
        [Route("cpAddress")]
        public async Task<ActionResult<Servicio>> cpAddress(string cp)
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Device", "POSTMAN");
                client.DefaultRequestHeaders.Add("Version", "2.0.6.0");
                client.DefaultRequestHeaders.Add("Authorization", "Basic Y2hyaXN0b3BoZXJAZGV2ZWxvcC5teDpUZXN0aW5nRGV2ZWxvcDEyM0AuLi4=");


                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {


                    var responseContent = await response.Content.ReadAsStringAsync();

                    string jsonString = JsonConvert.DeserializeObject<string>(responseContent);
                    var res = JsonConvert.DeserializeObject<string>(jsonString);

                    Servicio resultado = JsonConvert.DeserializeObject<Servicio>(res);

                    var addresses = resultado.addresses;

                    var ord = from Address in addresses
                              where Address.postalCode == cp
                              select Address;




                    return Ok(ord);


                }
                else
                {
                    return BadRequest();
                }

            }
        }

    }
}
