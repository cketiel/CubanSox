using CubanSox.Backend.Data;
using CubanSox.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace CubanSox.Backend.Services
{
    public class BoxScoreService : IBoxScoreService
    {
        private readonly AppDbContext _context;
        public BoxScoreService(AppDbContext context) => _context = context;

        public async Task<List<BoxScore>> GetByGameIdAsync(int gameId)
        {
            return await _context.BoxScores
                .Include(b => b.Team)
                .Include(b => b.Innings) // Cargamos todos los innings (1 al N)
                .Where(b => b.GameId == gameId)
                .ToListAsync();
        }

        public async Task<BoxScore> UpsertAsync(BoxScore boxScore)
        {
            // 1. Buscamos si ya existe el registro para este equipo en este juego
            var existing = await _context.BoxScores
                .Include(b => b.Innings)
                .FirstOrDefaultAsync(b => b.GameId == boxScore.GameId && b.TeamId == boxScore.TeamId);

            if (existing == null)
            {
                // 2. Si no existe, es nuevo. Aseguramos que los IDs de innings sean 0 para que EF los cree
                foreach (var inning in boxScore.Innings) inning.Id = 0;
                _context.BoxScores.Add(boxScore);
            }
            else
            {
                // 3. Si existe, actualizamos los campos básicos
                existing.R = boxScore.R;
                existing.H = boxScore.H;
                existing.E = boxScore.E;

                // 4. Actualizar Innings: Borramos los actuales y agregamos los nuevos
                _context.InningScores.RemoveRange(existing.Innings);

                foreach (var inning in boxScore.Innings)
                {
                    inning.Id = 0; // Importante: resetear ID para nueva inserción
                    inning.BoxScoreId = existing.Id;
                    existing.Innings.Add(inning);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Si falla, esto te dirá por qué en la consola del Backend
                Console.WriteLine($"Error en SaveChanges: {ex.Message}");
                throw;
            }

            return boxScore;
        }
    }
}
