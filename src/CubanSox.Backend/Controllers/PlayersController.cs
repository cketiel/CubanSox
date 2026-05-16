using CubanSox.Backend.Models;
using CubanSox.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CubanSox.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _playerService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var player = await _playerService.GetByIdAsync(id);
            return player == null ? NotFound() : Ok(player);
        }

        [HttpGet("team/{teamId}")]
        public async Task<IActionResult> GetByTeam(int teamId)
        {
            return Ok(await _playerService.GetByTeamAsync(teamId));
        }

        [HttpPost]
        public async Task<ActionResult<Player>> Create([FromBody] Player player)
        {
            try
            {
                var createdPlayer = await _playerService.CreateAsync(player);
                return CreatedAtAction(nameof(GetById), new { id = createdPlayer.Id }, createdPlayer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Player player)
        {
            try
            {
                var updated = await _playerService.UpdateAsync(id, player);
                return updated ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _playerService.DeleteAsync(id);
                return deleted ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}