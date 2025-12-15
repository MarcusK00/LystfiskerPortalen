using LystfiskerPortalen.Models;

namespace LystfiskerPortalen.Interfaces
{
    public interface ILocationRepository
    {
        Task<Location> GetByIdAsync(int id);
        Task<List<Location>> GetAllAsync();
    }
}
