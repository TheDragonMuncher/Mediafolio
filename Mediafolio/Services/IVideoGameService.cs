using MediaManager.Core.DTOs;
using MediaManager.Core.Models;

namespace Mediafolio.Services;

public interface IVideoGameService {
    Task<ICollection<VideoGame>> GetAllGames();
    Task<VideoGame?> GetGameById(int id);
    Task<VideoGame> CreateGame(CreateVideoGameDto dto);
    Task<VideoGame> UpdateGame(UpdateVideoGameDto dto);
    Task<bool> DeleteGame(int id);
}