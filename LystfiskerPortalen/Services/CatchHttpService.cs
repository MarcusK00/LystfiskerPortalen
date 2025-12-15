using LystfiskerPortalen.Interfaces;
using LystfiskerPortalen.Models;
using System.Text;

using System.Text.Json;
namespace LystfiskerPortalen.Services
{
    public class CatchHttpService : ICatchHttpService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CatchHttpService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task AddAsync(Catch _catch)
        {
            var httpClient = httpClientFactory.CreateClient("LystfiskerPortalenAPI"); // From middleware with base uri adress.

            var json = JsonSerializer.Serialize(_catch);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/catch", content);

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Post created!");
        }

        public async Task DeleteAsync(int id)
        {
            var httpClient = httpClientFactory.CreateClient("LystfiskerPortalenAPI");

            var response = await httpClient.DeleteAsync($"/api/catch/{id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Catch>> GetAllAsync()
        {
            var httpClient = httpClientFactory.CreateClient("LystfiskerPortalenAPI");

            var response = await httpClient.GetAsync("/api/catch/getall");

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Got response!");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var json = await response.Content.ReadAsStringAsync();

            // Deserialize into a List of userposts
            List<Catch>? catches = JsonSerializer.Deserialize<List<Catch>>(json, options);

            // Return list
            return catches!;
        }

        public async Task<Catch> GetByIdAsync(int id)
        {
            var httpClient = httpClientFactory.CreateClient("LystfiskerPortalenAPI");

            var response = await httpClient.GetAsync($"api/catch/{id}");

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Got response!");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var json = await response.Content.ReadAsStringAsync();

            Catch? _catch = JsonSerializer.Deserialize<Catch>(json, options);

            return _catch!;
        }

        public Task<Catch> GetByUserIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Catch> UpdateAsync(Catch _catch)
        {
            throw new NotImplementedException();
        }
    }
}
