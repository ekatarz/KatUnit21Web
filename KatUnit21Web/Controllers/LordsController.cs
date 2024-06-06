using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace KatUnit21Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LordsController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public LordsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("/lords")]
        public async Task<IActionResult> GetLordsData(string party)
        {
            try
            {
                var apiKey = "GrgwXJA2eKjjHGmpB2ADcBcJ";
                var response = await _httpClient.GetAsync($"https://www.theyworkforyou.com/api/getLords?party={party}&output=json&key={apiKey}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    return BadRequest($"Failed to fetch Lords from the API: {errorMessage}");
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                return Content(jsonString, "application/json");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error fetching Lords from the API: {ex.Message}");
            }
        }
    }
}
