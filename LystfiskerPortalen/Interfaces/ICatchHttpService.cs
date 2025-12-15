using LystfiskerPortalen.Models;

namespace LystfiskerPortalen.Interfaces
{
    public interface ICatchHttpService
    {
        public Task AddAsync(Catch _catch);
        public Task DeleteAsync(int id);
        public Task<Catch> UpdateAsync(Catch _catch);
        public Task<List<Catch>> GetAllAsync();
        public Task<Catch> GetByIdAsync(int id);
        public Task<Catch> GetByUserIdAsync(string id);
    }
}
