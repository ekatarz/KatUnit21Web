using KatUnit21Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PayPalCheckoutSdk.Orders;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace KatUnit21Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly TheyWorkForYouApiService _apiService;
        private readonly IConfiguration _configuration;

        public HomeController(TheyWorkForYouApiService apiService, IConfiguration configuration)
        {
            _apiService = apiService;
            _configuration = configuration;
        }
        [HttpGet("/home/mps")]
        public async Task<IActionResult> GetMpsData(string date)
        {
            try
            {
                var parsedDate = DateTime.Parse(date);
                var mps = await _apiService.GetMpsAsync(parsedDate);
                return Ok(mps);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpGet("/home/person/{id}")]
        public async Task<IActionResult> GetPersonDetails(string id)
        {
            try
            {
                var personDetails = await _apiService.GetPersonDetailsAsync(id);
                return Ok(personDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        // the donation request
        [HttpPost("/home/donate")]
        public async Task<IActionResult> Donate()
        {
            var clientId = _configuration["PayPal:ClientId"];
            var clientSecret = _configuration["PayPal:ClientSecret"];

            // initialize PayPal client
            var payPalClient = new PayPalClient(clientId, clientSecret);

            // create a donation order
            var orderResponse = await payPalClient.CreateOrder(10.00m, "GBP");

            //redirect user to PayPal
            return Redirect(orderResponse.Links[1].Href);
        }
    }
}