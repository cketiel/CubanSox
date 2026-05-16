using CubanSox.Backend.Models;

namespace CubanSox.Backend.Services
{
    public interface IBattingStatService
    {
        Task<List<BattingStat>> GetAllAsync();
        Task<List<BattingStat>> GetByGameAsync(int gameId);
        Task<BattingStat> UpsertAsync(BattingStat stat);
        Task<bool> DeleteAsync(int id);
        Task<List<BattingStat>> GetPlayerSeasonStatsAsync(int playerId); // Para el ranking histórico
    }
}