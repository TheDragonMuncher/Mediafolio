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
    public async Task<ActionResult<IEnumerable<VideoGame>>> GetById(int id)
    {
        var videoGame = await _repository.GetByIdAsync(id);

        if (videoGame == null)
        {
            return NotFound(new { message = $"Video game with id: {id} not found" });
        }

        return Ok(videoGame);
    }


}