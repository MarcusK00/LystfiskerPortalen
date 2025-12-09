using LystfiskerPortalen.Models;

namespace LystfiskerPortalen.Interfaces
{
    public interface IFishHttpService
    {
        public Task<List<Fish>> GetAllAsync();
        public Task<Fish> GetByIdAsync(int id);
    }
}
