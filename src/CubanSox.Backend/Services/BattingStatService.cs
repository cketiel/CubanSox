using CubanSox.Backend.Data;
using CubanSox.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace CubanSox.Backend.Services
{
    public class BattingStatService : IBattingStatService
    {
        private readonly AppDbContext _context;

        public BattingStatService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BattingStat>> GetAllAsync()
        {
            return await _context.BattingStats           
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<BattingStat>> GetByGameAsync(int gameId)
        {
            return await _context.BattingStats
                .Include(s => s.Player)
                .Where(s => s.GameId == gameId)
                .OrderBy(s => s.Order) // Orden al bate
                .ToListAsync();
        }

        public async Task<BattingStat> UpsertAsync(BattingStat stat)
        {
            stat.Player = null; // Seguridad extra

            var existing = await _context.BattingStats
                .FirstOrDefaultAsync(s => s.GameId == stat.GameId && s.PlayerId == stat.PlayerId);

            if (existing == null)
            {
                _context.BattingStats.Add(stat);
            }
            else
            {
                // Actualizamos campo por campo para evitar errores de mapeo
                existing.Position = stat.Position;
                existing.Order = stat.Order;
                existing.AB = stat.AB;
                existing.H = stat.H;
                existing.Doubles = stat.Doubles;
                existing.Triples = stat.Triples;
                existing.HR = stat.HR;
                existing.BB = stat.BB;
                existing.SO = stat.SO;
                existing.R = stat.R;
                existing.RBI = stat.RBI;
                existing.SB = stat.SB;
                existing.HBP = stat.HBP;
                existing.SF = stat.SF;
                existing.E = stat.E;
            }

            await _context.SaveChangesAsync();
            return stat;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var stat = await _context.BattingStats.FindAsync(id);
            if (stat == null) return false;

            _context.BattingStats.Remove(stat);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<BattingStat>> GetPlayerSeasonStatsAsync(int playerId)
        {
            return await _context.BattingStats
                .Where(s => s.PlayerId == playerId)
                .ToListAsync();
        }
    }
}