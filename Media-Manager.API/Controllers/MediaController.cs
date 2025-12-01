using System.Collections.Generic;
using Media_Manager.Core.Interfaces;
using MediaManager.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Media_Manager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaRepository mediaRepository;

        public MediaController(IMediaRepository repository)
        {
            mediaRepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<MediaObject>>> GetAllMedia()
        {
            var media = await mediaRepository.GetAllMedia();
            return Ok(media);
        }

        [HttpGet("{MediaId}")]
        public async Task<ActionResult<MediaObject>> GetMediabyId(int MediaId)
        {
            var media = mediaRepository.GetMediaById(MediaId);
            if (media == null)
            {
                return NotFound($"The media with Id: {MediaId} was not found");
            }

            return Ok(media);
        }
    }
}
