using CubanSox.Backend.Models;
using CubanSox.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CubanSox.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _gameService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var game = await _gameService.GetByIdAsync(id);
            return game == null ? NotFound() : Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> Create([FromBody] Game game)
        {
            try
            {
                var created = await _gameService.CreateAsync(game);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Game game)
        {
            try
            {
                var updated = await _gameService.UpdateAsync(id, game);
                return updated ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _gameService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}