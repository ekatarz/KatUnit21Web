using KatUnit21Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace KatUnit21Web.Services
{
    public class TheyWorkForYouApiService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "GrgwXJA2eKjjHGmpB2ADcBcJ";

        public TheyWorkForYouApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<MPData>> GetMpsAsync(DateTime date)
        {
            try
            {
                var dateString = date.ToString("yyyy-MM-dd"); 
                var apiUrl = $"https://www.theyworkforyou.com/api/getMPs?key={ApiKey}&date={dateString}";
                var response = await _httpClient.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to fetch MPs. Status code: {response.StatusCode}");
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                var mps = JsonSerializer.Deserialize<List<MPData>>(jsonString);
                return mps;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching MPs from the API", ex);
            }
        }
    
        public async Task<PersonDetails> GetPersonDetailsAsync(string id)
        {
            var apiUrl = $"https://www.theyworkforyou.com/api/getPerson?id={id}&output=json&key={ApiKey}";

            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch person details. Status code: {response.StatusCode}");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var personDetails = JsonSerializer.Deserialize<PersonDetails>(jsonString);

            return personDetails;
        }

        public async Task<IEnumerable<LordData>> GetLordsAsync(string party)
        {
            try
            {
                var apiUrl = $"https://www.theyworkforyou.com/api/getLords?party={party}&output=json&key={ApiKey}";
                var response = await _httpClient.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to fetch Lords. Status code: {response.StatusCode}");
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                var lords = JsonSerializer.Deserialize<List<LordData>>(jsonString);

                return lords;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching Lords from the API", ex);
            }
        }


 public class MPData
        {
            public string member_id { get; set; }
            public string person_id { get; set; }
            public string name { get; set; }
            public string party { get; set; }
            public string constituency { get; set; }
        }
    }
}