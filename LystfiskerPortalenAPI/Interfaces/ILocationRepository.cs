using LystfiskerPortalen.Models;

namespace LystfiskerPortalenAPI.Interfaces
{
    public interface ILocationRepository
    {
        Task<Location> GetByIdAsync(int id);
        Task<List<Location>> GetAllAsync();
    }
}
