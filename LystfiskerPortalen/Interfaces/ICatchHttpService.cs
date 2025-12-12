using LystfiskerPortalenShared.Models;

namespace LystfiskerPortalen.Interfaces
{
    public interface ICatchHttpService
    {
        public Task AddAsync(Catch userCatch);
        public Task DeleteAsync(int id);
        public Task<Catch> UpdateAsync(Catch userCatch);
        public Task<List<Catch>> GetAllAsync();
        public Task<Catch> GetByIdAsync(int id);
    }
}
