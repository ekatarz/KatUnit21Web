using KatUnit21Web.Interfaces;
using KatUnit21Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace KatUnit21Web.Services
{
    public class MpService : IMpService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "GrgwXJA2eKjjHGmpB2ADcBcJ";

        public MpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<MP>> GetMpsAsync()
        {
            var response = await _httpClient.GetStringAsync($"https://www.theyworkforyou.com/api/getMPs?key={_apiKey}&output=js");
            Console.WriteLine("API Response:");
            Console.WriteLine(response); //log the API response

            //convert php serialised response to a list of MPs
            var mps = ParsePhpStyleSerializedResponse(response);
            return mps;
        }

        private IEnumerable<MP> ParsePhpStyleSerializedResponse(string response)
        {
            //response starts with a :{ so remove that part here
            var json = response.Substring(response.IndexOf(":{") + 1);
            //remove the closing bracket at the end
            json = json.Remove(json.Length - 1);

            // deserialize the JSON string to a list of MPs
            var mps = JsonSerializer.Deserialize<List<MP>>(json);
            return mps;
        }
    }
}