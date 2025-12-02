using LystfiskerPortalen.Models;
namespace LystfiskerPortalen.Interfaces
{
    public interface IUserPostHttpService
    {
        public Task AddAsync(UserPost userPost);
        public Task DeleteAsync(UserPost userPost);
        public Task<UserPost> UpdateAsync(UserPost userPost);
        public Task<List<UserPost>> GetAllAsync();
        public Task<UserPost> GetByIdAsync(int id);
        public Task<UserPost> GetByUserIdAsync(string id);
    }
}
