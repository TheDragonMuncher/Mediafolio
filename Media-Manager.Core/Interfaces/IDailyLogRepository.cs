using MediaManager.Core.Models;

namespace MediaManager.Core.Interfaces;

public interface IDailyLogRepository
{
    Task<DailyLog> GetByIdAsync(int id);
    Task<ICollection<DailyLog>> GetAllAsync();
    Task<DailyLog> CreateAsync(DailyLog log, int mediaObjectId);
    Task<DailyLog> UpdateAsync(DailyLog log);
    Task<bool> DeleteAsync(int id);
}