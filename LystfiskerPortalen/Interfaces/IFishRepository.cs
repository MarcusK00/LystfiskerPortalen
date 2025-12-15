using LystfiskerPortalen.Models;

namespace LystfiskerPortalen.Interfaces
{
    public interface IFishRepository
    {
        Task<Fish> GetByIdAsync(int id);
        Task<List<Fish>> GetAllAsync();
    }
}
