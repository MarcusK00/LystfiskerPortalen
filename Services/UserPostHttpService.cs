using LystfiskerPortalen.Interfaces;
using LystfiskerPortalen.Controllers;
using LystfiskerPortalen.Models;
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

        public async void AddAsync(UserPost userPost)
        {
            using var httpClient = httpClientFactory.CreateClient();

            var json = JsonSerializer.Serialize(userPost);
            var content = new StringContent(json);

            var response = await httpClient.PostAsync("/api/userpost/post", content);

            response.EnsureSuccessStatusCode();
        }

        public void DeleteAsync(UserPost userPost)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserPost>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserPost> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserPost> GetByUserIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UserPost> UpdateAsync(UserPost userPost)
        {
            throw new NotImplementedException();
        }
    }
}
