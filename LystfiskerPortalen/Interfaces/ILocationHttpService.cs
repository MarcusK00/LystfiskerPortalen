using LystfiskerPortalen.Models;

namespace LystfiskerPortalen.Interfaces
{
    public interface ILocationHttpService
    {
        public Task<List<Location>> GetAllAsync();
        public Task<Location> GetByIdAsync(int id);
    }
}
