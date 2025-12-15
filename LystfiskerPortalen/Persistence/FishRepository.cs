using LystfiskerPortalen.Models;
using LystfiskerPortalen.Data;
using LystfiskerPortalen.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LystfiskerPortalen.Persistence
{
    public class FishRepository : IFishRepository
    {
        private ProjectDbContext _dbContext { get; set; }
        public FishRepository(ProjectDbContext context) //Context from dependency injection
        {
            _dbContext = context;
        }

        public async Task<List<Fish>> GetAllAsync()
        {
            return await _dbContext.Fishes.ToListAsync();
        }

        public async Task<Fish> GetByIdAsync(int id)
        {
            return await _dbContext.Fishes.Where(f => f.Id == id).FirstOrDefaultAsync();
        }
    }
}
