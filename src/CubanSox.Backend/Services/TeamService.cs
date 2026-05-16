using CubanSox.Backend.Data;
using CubanSox.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;

namespace CubanSox.Backend.Services
{
    public class TeamService : ITeamService
    {
        private readonly AppDbContext _context;
        public TeamService(AppDbContext context) 
        {
            _context = context;
        }
        public async Task<List<Team>> GetAllAsync()
        {
            return await _context.Teams
                .AsNoTracking()
                .Select(t => new Team
                {
                    Id = t.Id,
                    Name = t.Name,
                    Logo = t.Logo
                })
                .ToListAsync();
        }
        public async Task<Team?> GetByIdAsync(int id)
        {
            var t = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
            if (t == null) return null;
            return new Team
            {
                Id = t.Id,
                Name = t.Name,
                Logo = t.Logo
            };
        }

        public async Task<Team> CreateAsync(Team team) 
        { 
            if (string.IsNullOrWhiteSpace(team.Name))
                throw new ArgumentException("Team name is required.");
            var newTeam = new Team
            {
                Name = team.Name,
                Logo = team.Logo
            };
            try
            {
                _context.Teams.Add(newTeam);
                await _context.SaveChangesAsync();
                return newTeam;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<bool> UpdateAsync(int id, Team team) 
        { 
            var existingTeam = await _context.Teams.FindAsync(id);
            if (existingTeam == null) return false;
            existingTeam.Name = team.Name;
            existingTeam.Logo = team.Logo;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id) 
        {
            var existingTeam = await _context.Teams.FindAsync(id);
            if (existingTeam == null) return false;
            _context.Teams.Remove(existingTeam);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
