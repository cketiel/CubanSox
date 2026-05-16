using CubanSox.Backend.Models;

namespace CubanSox.Backend.Services
{
    public interface IPlayerService
    {
        Task<List<Player>> GetAllAsync();
        Task<Player?> GetByIdAsync(int id);
        Task<List<Player>> GetByTeamAsync(int teamId); // Útil para filtrar por equipo
        Task<Player> CreateAsync(Player player);
        Task<bool> UpdateAsync(int id, Player player);
        Task<bool> DeleteAsync(int id);
    }
}
