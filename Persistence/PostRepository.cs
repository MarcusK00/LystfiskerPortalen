using LystfiskerPortalen.Data;
using LystfiskerPortalen.Interfaces;
using LystfiskerPortalen.Models;
using Microsoft.EntityFrameworkCore;

namespace LystfiskerPortalen.Persistence
{
    public class PostRepository : IPostRepository
    {
        private PostDbContext _dbContext { get; set; }
        public PostRepository(PostDbContext context) //Context from dependency injection
        {
            _dbContext = context; 
        }
        public async Task AddAsync(Post post) // Add a new post to DbContext
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

        public async Task<List<Post>> GetAllAsync() // Gets all the posts
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public Task<List<Post>> GetAllByUserIdAsync(string userId)
        {
            throw new NotImplementedException(); // Needs implementation
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            Post post = await _dbContext.Posts.FirstOrDefaultAsync(i => i.Id == id); // Id prop missing
            if (post == null) throw new Exception("Post not found");

            return post;
        }

        public async Task UpdateAsync(int id, Post newPost) // Updates existing post based on id with new post 
        {
            if (id < 0 || newPost == null) throw new Exception("Post not found");
            Post existingPost = await _dbContext.Posts.FirstOrDefaultAsync(i => i.Id == id);

            existingPost = newPost;
            await _dbContext.SaveChangesAsync(); 
        }
    }
}
