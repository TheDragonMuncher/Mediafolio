using Mediafolio.DTOs;
using Mediafolio.Models;

namespace Mediafolio.Services;

public interface IVideoGameService {
    Task<List<VideoGame>> GetAllGames();
    Task<VideoGame?> GetGameById(int id);
    Task<VideoGame> CreateGame(CreateVideoGameDto dto);
    Task<VideoGame> UpdateGame(int id, UpdateVideoGameDto dto);
    Task<bool> DeleteGame(int id);
}