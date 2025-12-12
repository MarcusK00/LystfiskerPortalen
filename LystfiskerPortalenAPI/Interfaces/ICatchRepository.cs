using LystfiskerPortalen.Models;

namespace LystfiskerPortalenAPI.Interfaces
{
    public interface ICatchRepository
    {
        Task AddAsync(Catch userPost);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, Catch userPost);
        Task<List<Catch>> GetAllAsync();
        Task<Catch> GetByIdAsync(int id);
    }
}
