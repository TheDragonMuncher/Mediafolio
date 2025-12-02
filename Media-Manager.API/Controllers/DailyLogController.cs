using MediaManager.Core.DTOs;
using MediaManager.Core.Interfaces;
using MediaManager.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Media_Manager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyLogController : ControllerBase
    {
        private readonly IDailyLogRepository _repository;

        public DailyLogController(IDailyLogRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DailyLog>>> GetAllDailyLogs()
        {
            var dailyLogs = await _repository.GetAllAsync();
            return Ok(dailyLogs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DailyLog>> GetDailyLogById(int id)
        {
            var dailyLogs = await _repository.GetByIdAsync(id);

            if (dailyLogs == null)
                return null;

            return Ok(dailyLogs);
        }

        [HttpPost("{mediaId}")]
        public async Task<ActionResult<DailyLog>> CreateDailyLog(int mediaId, [FromBody] CreateDailyLogDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dailyLog = new DailyLog
            {
                Content = dto.Content,
                UsageTime = dto.UsageTime,
                MediaObjectId = dto.MediaObjectId
            };

            var createdDailyLog = await _repository.CreateAsync(dailyLog, mediaId);

            return CreatedAtAction(
                nameof(GetDailyLogById),
                new { id = dailyLog.Id },
                dailyLog);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDailyLog(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound($"daily log with id: {id} not found");
            }
            return NoContent();
        }


    }
}
