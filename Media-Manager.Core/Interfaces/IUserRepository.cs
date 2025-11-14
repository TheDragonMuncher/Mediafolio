using MediaManager.Core.Models;

namespace MediaManager.Core.Interfaces;

public interface IUserRepository
{
    Task<ICollection<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task<ICollection<MediaObject>> GetAllMediaObjectsAsync();
    Task<ICollection<VideoGame>> GetAllVideoGamesAsync();
    Task<ICollection<Video>> GetAllVideosAsync();
    Task<ICollection<Book>> GetAllBooksAsync();
    Task<User> CreateAsync(User user, Role role);
    Task<User> UpdateAsync(User? user, Role? role);
    Task<bool> DeleteAsync(int id);
}