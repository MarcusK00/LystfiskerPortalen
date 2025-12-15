using LystfiskerPortalen.Models;

namespace LystfiskerPortalen.Interfaces
{
    public interface ICatchRepository
    {
        Task AddAsync(Catch userCatch);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, Catch newCatch);
        Task<List<Catch>> GetAllAsync();
        Task<Catch> GetByIdAsync(int id);
    }
}
