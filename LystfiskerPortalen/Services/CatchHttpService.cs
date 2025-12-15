using LystfiskerPortalen.Interfaces;
using LystfiskerPortalenShared.Models;
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

        public async Task AddAsync(Catch userCatch)
        {
            var httpClient = httpClientFactory.CreateClient("LystfiskerPortalenAPI"); // From middleware with base uri adress.

            var json = JsonSerializer.Serialize(userCatch);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/catch", content);

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Catch added!");
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Catch>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Catch> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Catch> UpdateAsync(Catch userCatch)
        {
            throw new NotImplementedException();
        }
    }
}
