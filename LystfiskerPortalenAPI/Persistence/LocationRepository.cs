using LystfiskerPortalenShared.Models;
using LystfiskerPortalenShared.Data;
using LystfiskerPortalenAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LystfiskerPortalenAPI.Persistence
{
    public class LocationRepository : ILocationRepository
    {
        private ProjectDbContext _dbContext { get; set; }
        public LocationRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Location>> GetAllAsync()
        {
            return await _dbContext.Locations.ToListAsync();
        }

        public async Task<Location> GetByIdAsync(int id)
        {
            if(id <= 0) throw new Exception("LocationId cant be equal to 0 or less than 0");
            var location = await _dbContext.Locations.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (location == null) throw new Exception("Location not found");
            return location;
        }
    }
}
