using System.Net.Http;

namespace CivicApi
{
    public class Civic
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "https://civicapi.org/api/v2";
        public Civic()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/142.0.0.0 Safari/537.36");
        }

        public async Task<string> GetStatus()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/status");
            return await response.Content.ReadAsStringAsync();
        }
        
        public async Task<string> SearchRace(
            string startDate,
            string endDate, 
            string query, 
            string country,
            string? province = null,
            string? district = null,
            int? limit = null)
        {
            var url = $"{apiUrl}/race/search?startDate={startDate}&endDate={endDate}&query={query}&country={country}";
            if (!string.IsNullOrEmpty(province)) url += $"&province={province}";
            if (!string.IsNullOrEmpty(district)) url += $"&district={district}";
            if (limit.HasValue) url += $"&limit={limit}";
            var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetRaceHistory(string raceId)
        {
            var response = await httpClient.GetAsync($"{apiUrl}/race/{raceId}/history");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetElectionDates()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/getElectionDates");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
