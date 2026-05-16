using CubanSox.Backend.Data;
using CubanSox.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace CubanSox.Backend.Services
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _context;

        public GameService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Game>> GetAllAsync()
        {
            return await _context.Games
                .Include(g => g.HomeTeam)
                .Include(g => g.VisitorTeam)
                .OrderByDescending(g => g.Date) // Juegos más recientes primero
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _context.Games
                .Include(g => g.HomeTeam)
                .Include(g => g.VisitorTeam)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Game> CreateAsync(Game game)
        {
            // Evitar que EF intente crear equipos nuevos que ya existen
            game.HomeTeam = null;
            game.VisitorTeam = null;

            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<bool> UpdateAsync(int id, Game game)
        {
            var existingGame = await _context.Games.FindAsync(id);
            if (existingGame == null) return false;

            existingGame.Date = game.Date;
            existingGame.Time = game.Time; 
            existingGame.Field = game.Field;
            existingGame.HomeTeamId = game.HomeTeamId;
            existingGame.VisitorTeamId = game.VisitorTeamId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null) return false;

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}