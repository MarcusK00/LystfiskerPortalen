using LystfiskerPortalen.Interfaces;
using LystfiskerPortalenShared.Models;
using System.Text.Json;

namespace LystfiskerPortalen.Services
{
    public class LocationHttpService : ILocationHttpService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public LocationHttpService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<List<Location>> GetAllAsync()
        {
            var httpClient = httpClientFactory.CreateClient("LystfiskerPortalenAPI");

            var response = await httpClient.GetAsync("/api/location/getall");

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Got response!");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var json = await response.Content.ReadAsStringAsync();

            // Deserialize into a List of userposts
            List<Location>? locations = JsonSerializer.Deserialize<List<Location>>(json, options);

            // Return list
            return locations!;
        }

        public async Task<Location> GetByIdAsync(int id)
        {
            var httpClient = httpClientFactory.CreateClient("LystfiskerPortalenAPI");

            var response = await httpClient.GetAsync($"api/location/{id}");

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Got response!");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var json = await response.Content.ReadAsStringAsync();

            Location? location = JsonSerializer.Deserialize<Location>(json, options);

            return location!;
        }
    }
}
