using LystfiskerPortalen.Interfaces;
using LystfiskerPortalenShared.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LystfiskerPortalen.Services
{
    public class UserPostHttpService : IUserPostHttpService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public UserPostHttpService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task AddAsync(UserPost userPost)
        {

            var httpClient = httpClientFactory.CreateClient("LystfiskerPortalenAPI"); // From middleware with base uri adress.

            var json = JsonSerializer.Serialize(userPost);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/userpost", content);

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Post created!");
        }

        public async Task DeleteAsync(int id)
        {
            var httpClient = httpClientFactory.CreateClient("LystfiskerPortalenAPI");

            var response = await httpClient.DeleteAsync($"/api/userpost/{id}");

            response.EnsureSuccessStatusCode();

        }

        public async Task<List<UserPost>> GetAllAsync()
        {
            var httpClient = httpClientFactory.CreateClient("LystfiskerPortalenAPI");

            var response = await httpClient.GetAsync("/api/userpost/getall");

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Got response!");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var json = await response.Content.ReadAsStringAsync();

            // Deserialize into a List of userposts
            List<UserPost>? posts = JsonSerializer.Deserialize<List<UserPost>>(json, options);

            // Return list
            return posts!;
        }

        public async Task<UserPost> GetByIdAsync(int id)
        {
            var httpClient = httpClientFactory.CreateClient("LystfiskerPortalenAPI");

            var response = await httpClient.GetAsync($"api/userpost/{id}");

            response.EnsureSuccessStatusCode();
            Console.WriteLine("Got response!");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var json = await response.Content.ReadAsStringAsync();

            UserPost? userPost = JsonSerializer.Deserialize<UserPost>(json, options);

            return userPost!;
        }

        public async Task<UserPost> GetByUserIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserPost> UpdateAsync(UserPost userPost)
        {
            throw new NotImplementedException();
        }
    }
}
