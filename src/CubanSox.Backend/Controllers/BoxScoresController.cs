using CubanSox.Backend.Models;
using CubanSox.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CubanSox.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoxScoresController : ControllerBase
    {
        private readonly IBoxScoreService _boxService;
        public BoxScoresController(IBoxScoreService boxService) => _boxService = boxService;

        [HttpGet("game/{gameId}")]
        public async Task<IActionResult> GetByGame(int gameId) => Ok(await _boxService.GetByGameIdAsync(gameId));

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] BoxScore boxScore) => Ok(await _boxService.UpsertAsync(boxScore));
    }
}
