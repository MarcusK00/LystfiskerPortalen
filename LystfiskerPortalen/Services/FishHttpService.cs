using LystfiskerPortalen.Interfaces;
using LystfiskerPortalenShared.Models;
using System.Text.Json;

namespace LystfiskerPortalen.Services
{
    public class FishHttpService : IFishHttpService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public FishHttpService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<List<Fish>> GetAllAsync()
        {
            var httpClient = httpClientFactory.CreateClient("LystfiskerPortalenAPI");

            var response = await httpClient.GetAsync("/api/fish/getall");

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Got response!");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var json = await response.Content.ReadAsStringAsync();

            // Deserialize into a List of fish
            List<Fish>? posts = JsonSerializer.Deserialize<List<Fish>>(json, options);

            // Return list
            return posts!;
        }

        public async Task<Fish> GetByIdAsync(int id)
        {
            var httpClient = httpClientFactory.CreateClient("LystfiskerPortalenAPI");

            var response = await httpClient.GetAsync($"api/fish/{id}");

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Got response!");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var json = await response.Content.ReadAsStringAsync();

            Fish? fish = JsonSerializer.Deserialize<Fish>(json, options);

            return fish!;
        }
    }
}
