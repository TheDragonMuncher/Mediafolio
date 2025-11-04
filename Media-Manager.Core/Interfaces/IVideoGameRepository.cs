using MediaManager.Core.Models;

namespace MediaManager.Core.Interfaces;

public interface IVideoGameRepository
{
    Task<ICollection<VideoGame>> GetAllAsync();
    Task<VideoGame> GetByIdAsync(int id);
    Task<VideoGame> CreateAsync(VideoGame game);
    Task<bool> DeleteAsync(int id);
    Task<VideoGame> UpdateAsync(VideoGame game);
}