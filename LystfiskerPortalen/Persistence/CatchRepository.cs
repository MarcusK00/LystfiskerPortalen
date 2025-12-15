using LystfiskerPortalen.Data;
using LystfiskerPortalen.Interfaces;
using LystfiskerPortalen.Models;
using Microsoft.EntityFrameworkCore;

namespace LystfiskerPortalen.Persistence
{
    public class CatchRepository : ICatchRepository
    {
        private ProjectDbContext _dbContext { get; set; }
        public CatchRepository(ProjectDbContext context) //Context from dependency injection
        {
            _dbContext = context;
        }

        public async Task AddAsync(Catch userCatch)
        {
            await _dbContext.Catches.AddAsync(userCatch);
        }

        public async Task DeleteAsync(int id)
        {
            await _dbContext.Catches.Where(c => c.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<Catch>> GetAllAsync()
        {
            return await _dbContext.Catches.ToListAsync();
        }

        public async Task<Catch> GetByIdAsync(int id)
        {
            return await _dbContext.Catches.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public Task UpdateAsync(int id, Catch newCatch)
        {
            throw new NotImplementedException();
        }
    }
}
