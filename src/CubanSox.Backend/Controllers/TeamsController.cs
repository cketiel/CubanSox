using CubanSox.Backend.Models;
using CubanSox.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CubanSox.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _teamService.GetAllAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var trip = await _teamService.GetByIdAsync(id);
            return trip == null ? NotFound() : Ok(trip);
        }

        [HttpPost]
        public async Task<ActionResult<Team>> Create([FromBody] Team team)
        {
            try
            {
                var createdTeam = await _teamService.CreateAsync(team);
                return CreatedAtAction(nameof(GetById), new { id = createdTeam.Id }, createdTeam);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Team team) 
        {
            try
            {
                var updated = await _teamService.UpdateAsync(id, team);
                return updated ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
                //return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            try
            {
                var deleted = await _teamService.DeleteAsync(id);
                return deleted ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
                //return BadRequest(ex.Message);
            }
        }
    }
}
