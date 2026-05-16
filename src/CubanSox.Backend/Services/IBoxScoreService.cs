using CubanSox.Backend.Models;

namespace CubanSox.Backend.Services
{
    public interface IBoxScoreService
    {
        Task<List<BoxScore>> GetByGameIdAsync(int gameId);
        Task<BoxScore> UpsertAsync(BoxScore boxScore); // Crea o actualiza
    }
}