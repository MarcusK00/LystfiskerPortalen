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

        public async Task<List<Fish>> GetAllFish()
        {
            return await _dbContext.Fishes.ToListAsync();
        }

        public async Task<Fish> GetFishById(int id)
        {
            return await _dbContext.Fishes.Where(f => f.Id == id).FirstOrDefaultAsync();
        }
    }
}
