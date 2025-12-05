using Mediafolio.DTOs;
using Mediafolio.Models;

namespace Mediafolio.Services;

public interface IVideoGameService {
    Task<List<VideoGame>> GetAllGamesAsync();
    Task<VideoGame?> GetGameByIdAsync(int id);
    Task<VideoGame> CreateGameAsync(CreateVideoGameDto dto);
    Task<VideoGame> UpdateGameAsync(int id, UpdateVideoGameDto dto);
    Task<bool> DeleteGameAsync(int id);
}