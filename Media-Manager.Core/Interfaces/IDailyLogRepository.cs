using MediaManager.Core.Models;

namespace MediaManager.Core.Interfaces;

public interface IDailyLogRepository
{
    Task<DailyLog> GetById(int id);
    Task<ICollection<DailyLog>> GetAll();
    Task<DailyLog> Create(DailyLog log, int mediaObjectId);
    Task<DailyLog> Update(DailyLog log);
    Task<bool> Delete(int id);
}