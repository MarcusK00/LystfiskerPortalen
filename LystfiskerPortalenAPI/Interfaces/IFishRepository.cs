using LystfiskerPortalenShared.Models;

namespace LystfiskerPortalenAPI.Interfaces
{
    public interface IFishRepository
    {
        Task<Fish> GetByIdAsync(int id);
        Task<List<Fish>> GetAllAsync();
    }
}
