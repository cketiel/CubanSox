using CubanSox.Backend.Models;
using CubanSox.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CubanSox.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BattingStatsController : ControllerBase
    {
        private readonly IBattingStatService _statService;

        public BattingStatsController(IBattingStatService statService)
        {
            _statService = statService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _statService.GetAllAsync());
        }

        [HttpGet("game/{gameId}")]
        public async Task<IActionResult> GetByGame(int gameId)
        {
            return Ok(await _statService.GetByGameAsync(gameId));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] BattingStat stat)
        {
            try
            {
                var result = await _statService.UpsertAsync(stat);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _statService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}