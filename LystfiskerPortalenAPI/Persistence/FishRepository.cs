using LystfiskerPortalen.Models;
using LystfiskerPortalenAPI.Data;
using LystfiskerPortalenAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LystfiskerPortalenAPI.Persistence
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
