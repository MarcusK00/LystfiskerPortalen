using LystfiskerPortalen.Models;

namespace LystfiskerPortalen.Interfaces
{
    public interface IUserPostRepository
    {
        Task AddAsync(UserPost post);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, UserPost newPost);
        Task<List<UserPost>> GetAllAsync();
        Task<UserPost> GetByIdAsync(int id);
        Task<List<UserPost>> GetAllByUserIdAsync(string userId);
    }
}
