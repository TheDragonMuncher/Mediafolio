using MediaManager.Core.Models;

namespace MediaManager.Core.Interfaces;

public interface IUserRepository
{
    Task<ICollection<User>> GetallAsync();
    Task<User> GetByIdAsync();
}