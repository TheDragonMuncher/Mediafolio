using MediaManager.Core.Interfaces;
using MediaManager.Core.Models;
using MediaManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace MediaManager.Infrastructure.Repositories;

public class DailyLogRepository : IDailyLogRepository
{
    readonly ApplicationDbContext _context;
    public DailyLogRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<DailyLog> Create(DailyLog log, int mediaObjectId)
    {
        log.CreatedAt = DateTime.UtcNow;
        var mediaObject = await _context.MediaObjects.FindAsync(mediaObjectId);
        log.MediaObject = mediaObject;
        log.MediaObjectId = mediaObjectId;
        mediaObject.DailyLogs.Append(log);
        _context.DailyLogs.Add(log);
        await _context.SaveChangesAsync();
        return log;
    }

    public async Task<bool> Delete(int id)
    {
        var log = await _context.DailyLogs.FindAsync(id);
        if (log == null)
        {
            return false;
        }
        _context.DailyLogs.Remove(log);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<ICollection<DailyLog>> GetAll()
    {
        return await _context.DailyLogs.ToListAsync();
    }

    public async Task<DailyLog> GetById(int id)
    {
        return await _context.DailyLogs.FindAsync(id);
    }

    public async Task<DailyLog> Update(DailyLog log)
    {
        var currentLog = await _context.DailyLogs.FindAsync(log.Id);
        if (currentLog == null)
        {
            return null;
        }
        currentLog.Content = log.Content;
        currentLog.UsageTime = log.UsageTime;
        _context.DailyLogs.Update(currentLog);
        await _context.SaveChangesAsync();
        return currentLog;
    }
}