using MediaManager.Core.DTOs;
using MediaManager.Core.Interfaces;
using MediaManager.Core.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MediaManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoController : ControllerBase
{
    
    private readonly IVideoRepository _repository;

    public VideoController(IVideoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Video>>> GetAll()
    {
        var videos = await _repository.GetAllAsync();
        return Ok(videos);
    }



    [HttpGet("{id}")]
    public async Task<ActionResult<Video>> GetById(int id)
    {
        var video = await _repository.GetByIdAsync(id);

        if (video == null)
        {
            return NotFound();
        }

        return Ok(video);

    }

    //POST: api/video
    [HttpPost("userId")]
    public async Task<ActionResult<Task>> CreatePost([FromBody] CreateVideoDto videoDto, int userId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); 
        }

        var video = new Video
        {
          
          Title = videoDto.Title,
          Description = videoDto.Description,
          UserWatchTime = videoDto.UserWatchTime,
          VideoDuration = videoDto.VideoDuration,
          NumberOfEpisodes = videoDto.NumberOfEpisodes,
          Tags = videoDto.Tags

        };

        var createdVideo = await _repository.CreateAsync(video, userId);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdVideo.Id },
            createdVideo
        );
    }

}