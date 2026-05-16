using CubanSox.Backend.Models;

namespace CubanSox.Backend.Services
{
    public interface IGameService
    {
        Task<List<Game>> GetAllAsync();
        Task<Game?> GetByIdAsync(int id);
        Task<Game> CreateAsync(Game game);
        Task<bool> UpdateAsync(int id, Game game);
        Task<bool> DeleteAsync(int id);
    }
}
