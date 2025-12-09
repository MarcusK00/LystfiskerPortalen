using LystfiskerPortalen.Models;

namespace LystfiskerPortalenAPI.Interfaces
{
    public interface IFishRepository
    {
        Task<Fish> GetFishById(int id);
        Task<List<Fish>> GetAllFish();
    }
}
