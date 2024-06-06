using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace KatUnit21Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MPsController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public MPsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet("/mps")]
        public async Task<IActionResult> GetMpsData(string date)
        {
            try
            {
                var apiKey = "GrgwXJA2eKjjHGmpB2ADcBcJ";
                var response = await _httpClient.GetAsync($"https://www.theyworkforyou.com/api/getMPs?date={date}&key={apiKey}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    return BadRequest($"Failed to fetch MPs from the API: {errorMessage}");
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                return Content(jsonString, "application/json");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error fetching MPs from the API: {ex.Message}");
            }
        }

    }
}