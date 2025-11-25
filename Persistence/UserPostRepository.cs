using LystfiskerPortalen.Data;
using LystfiskerPortalen.Interfaces;
using LystfiskerPortalen.Models;
using Microsoft.EntityFrameworkCore;

namespace LystfiskerPortalen.Persistence
{
    public class UserPostRepository : IUserPostRepository
    {
        private PostDbContext _dbContext { get; set; }
        public UserPostRepository(PostDbContext context) //Context from dependency injection
        {
            _dbContext = context; 
        }
        public async Task AddAsync(UserPost post) // Add a new post to DbContext
        {
            if (post != null)
            {
                _dbContext.Posts.Add(post);
                await _dbContext.SaveChangesAsync();
            } 
            throw new Exception("Post not valid");
        }

        public async Task DeleteAsync(int id) // Deletes a post based on an id
        {
            if (id < 0) throw new Exception("Id less than 0");
            var post = await _dbContext.Posts.FirstOrDefaultAsync(i=>i.Id == id); // Id property is missing from Post model
            _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<UserPost>> GetAllAsync() // Gets all the posts
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public Task<List<UserPost>> GetAllByUserIdAsync(string userId)
        {
            throw new NotImplementedException(); // Needs implementation
        }

        public async Task<UserPost> GetByIdAsync(int id)
        {
            UserPost post = await _dbContext.Posts.FirstOrDefaultAsync(i => i.Id == id); // Id prop missing
            if (post == null) throw new Exception("Post not found");

            return post;
        }

        public async Task UpdateAsync(int id, UserPost newPost) // Updates existing post based on id with new post 
        {
            if (id < 0 || newPost == null) throw new Exception("Post not found");
            UserPost existingPost = await _dbContext.Posts.FirstOrDefaultAsync(i => i.Id == id);

            existingPost = newPost;
            await _dbContext.SaveChangesAsync(); 
        }
    }
}
