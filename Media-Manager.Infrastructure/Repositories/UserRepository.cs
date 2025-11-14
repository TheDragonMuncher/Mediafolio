using MediaManager.Core.Interfaces;
using MediaManager.Core.Models;
using MediaManager.Infrastructure.Data;

namespace MediaManager.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task<User> CreateAsync(User user, Role role)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Book>> GetAllBooksAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<MediaObject>> GetAllMediaObjectsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<VideoGame>> GetAllVideoGamesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Video>> GetAllVideosAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User? user, Role? role)
    {
        throw new NotImplementedException();
    }
}