using MediaManager.Core.Models;

namespace MediaManager.Core.Interfaces;

public interface IUserRepository
{
    Task<ICollection<User>> GetallAsync();
    Task<User> GetByIdAsync(int id);
    Task<User> CreateAsync(User user, Role role);
    Task<User> UpdateAsync(User user);
    Task<bool> DeleteAsync(int id);
}