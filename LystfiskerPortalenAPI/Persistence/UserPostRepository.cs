using LystfiskerPortalenAPI.Data;
using LystfiskerPortalenAPI.Interfaces;
using LystfiskerPortalen.Models;
using Microsoft.EntityFrameworkCore;

namespace LystfiskerPortalenAPI.Persistence
{
    public class UserPostRepository : IUserPostRepository
    {
        private ProjectDbContext _dbContext { get; set; }
        public UserPostRepository(ProjectDbContext context) //Context from dependency injection
        {
            _dbContext = context; 
        }
        public async Task AddAsync(UserPost post) // Add a new post to DbContext
        {
            if (post != null)
            {
                _dbContext.UserPosts.Add(post);
                await _dbContext.SaveChangesAsync();
            } 
            throw new Exception("Post not valid");
        }

        public async Task DeleteAsync(int id) // Deletes a post based on an id
        {
            if (id < 0) throw new Exception("Id less than 0");
            UserPost? post = await _dbContext.UserPosts.FirstOrDefaultAsync(i=>i.Id == id); 
            _dbContext.UserPosts.Remove(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<UserPost>> GetAllAsync() // Gets all the posts
        {
            return await _dbContext.UserPosts
                     .Include(u => u.User)
                     .Include(u => u.Catch!)
                     .ThenInclude(c => c.Fish) // Includes fish property data to JSON
                     .Include(u => u.Catch!)
                     .ThenInclude(c => c.Location) // Includes Location prop data to JSON
                     .ToListAsync(); 
        }

        public Task<List<UserPost>> GetAllByUserIdAsync(string userId)
        {
            throw new NotImplementedException(); // Needs implementation
        }

        public async Task<UserPost> GetByIdAsync(int id)
        {
            UserPost? post = await _dbContext.UserPosts.Where(u => u.Id == id)
                     .Include(u => u.User)
                     .Include(u => u.Catch!)
                     .ThenInclude(c => c.Fish) // Includes fish property data to JSON
                     .Include(u => u.Catch!)
                     .ThenInclude(c => c.Location) // Includes Location prop data to JSON
                     .FirstOrDefaultAsync();
            if (post == null) throw new Exception("Post not found");

            return post;
        }

        public async Task UpdateAsync(int id, UserPost newPost) // Updates existing post based on id with new post 
        {
            if (id < 0 || newPost == null) throw new Exception("Post not found");
            UserPost? existingPost = await _dbContext.UserPosts.FirstOrDefaultAsync(i => i.Id == id);

            existingPost = newPost;
            await _dbContext.SaveChangesAsync(); 
        }
    }
}
