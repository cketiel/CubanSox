using CubanSox.Backend.Data;
using CubanSox.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace CubanSox.Backend.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly AppDbContext _context;

        public PlayerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> GetAllAsync()
        {
            return await _context.Players
                .Include(p => p.Team) // Trae los datos del equipo relacionado
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Player?> GetByIdAsync(int id)
        {
            return await _context.Players
                .Include(p => p.Team)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Player>> GetByTeamAsync(int teamId)
        {
            return await _context.Players
                .Where(p => p.TeamId == teamId)
                .ToListAsync();
        }

        public async Task<Player> CreateAsync(Player player)
        {
            if (string.IsNullOrWhiteSpace(player.Name))
                throw new ArgumentException("El nombre del jugador es requerido.");

            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<bool> UpdateAsync(int id, Player player)
        {
            var existingPlayer = await _context.Players.FindAsync(id);
            if (existingPlayer == null) return false;

            existingPlayer.Name = player.Name;
            existingPlayer.Number = player.Number;           
            existingPlayer.DOB = player.DOB;
            existingPlayer.Photo = player.Photo;
            existingPlayer.TeamId = player.TeamId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingPlayer = await _context.Players.FindAsync(id);
            if (existingPlayer == null) return false;

            _context.Players.Remove(existingPlayer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
