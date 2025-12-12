using LystfiskerPortalenShared.Models;
using LystfiskerPortalenShared.Data;
using LystfiskerPortalenAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LystfiskerPortalenAPI.Persistence
{
    public class CatchRepository : ICatchRepository
    {
        private ProjectDbContext _dbContext { get; set; }
        public CatchRepository(ProjectDbContext context) //Context from dependency injection
        {
            _dbContext = context;
        }
        public async Task AddAsync(Catch userCatch) // Add a new post to DbContext
        {
            if (userCatch != null)
            {
                _dbContext.Catches.Add(userCatch);
                await _dbContext.SaveChangesAsync();
            }
            throw new Exception("Catch not valid");
        }

        public async Task DeleteAsync(int id) // Deletes a post based on an id
        {
            if (id < 0) throw new Exception("Id less than 0");
            Catch? userCatch = await _dbContext.Catches.FirstOrDefaultAsync(c => c.Id == id);
            _dbContext.Catches.Remove(userCatch);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Catch>> GetAllAsync() // Gets all the posts
        {
            return await _dbContext.Catches
                .Include(c => c.Location)
                .Include(c => c.Fish)
                .ToListAsync();
        }

        public async Task<Catch> GetByIdAsync(int id)
        {
            Catch? userCatch = await _dbContext.Catches.Where(u => u.Id == id)
                     .Include(c => c.Fish)
                     .Include(c => c.Location)
                     .FirstOrDefaultAsync();
            if (userCatch == null) throw new Exception("Post not found");

            return userCatch;
        }

        public async Task UpdateAsync(int id, Catch newPost) // Updates existing post based on id with new post 
        {
            if (id < 0 || newPost == null) throw new Exception("Post not found");
            Catch? existingPost = await _dbContext.Catches.FirstOrDefaultAsync(i => i.Id == id);

            existingPost = newPost;
            await _dbContext.SaveChangesAsync();
        }
    }
}
