using LystfiskerPortalen.Models;

namespace LystfiskerPortalen.Interfaces
{
    public interface IPostRepository
    {
        Task AddAsync(Post post);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, Post newPost);
        Task<List<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(int id);
        Task<List<Post>> GetAllByUserIdAsync(string userId);
    }
}
