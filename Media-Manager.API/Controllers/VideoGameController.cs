using MediaManager.Core.DTOs;
using MediaManager.Core.Interfaces;
using MediaManager.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediaManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoGameController : ControllerBase
{
    private readonly IVideoGameRepository _repository;

    public VideoGameController(IVideoGameRepository repository)
    {
        _repository = repository;
    }

    // GET: api/videoGames
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VideoGame>>> GetAll()
    {
        var videoGames = await _repository.GetAllAsync();
        return Ok(videoGames);
    }

    // GET: api/videoGames/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<VideoGame>> GetById(int id)
    {
        var videoGame = await _repository.GetByIdAsync(id);

        if (videoGame == null)
        {
            return NotFound(new { message = $"Video game with id: {id} not found" });
        }

        return Ok(videoGame);
    }

    // POST: api/videoGames
    [HttpPost]
    public async Task<ActionResult<VideoGame>> Create([FromBody] CreateVideoGameDto videoGameDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var videoGame = new VideoGame
        {
            Title = videoGameDto.Title,
            Description = videoGameDto.Description,
            EstimatedPlayTime = videoGameDto.EstimatedPlayTime,
            UserPlayTime = videoGameDto.UserPlayTime,
            Tags = videoGameDto.Tags,
            CreatedAt = DateTime.UtcNow
        };

        var createdVideoGame = await _repository.CreateAsync(videoGame);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdVideoGame.Id },
            createdVideoGame
        );
    }
}