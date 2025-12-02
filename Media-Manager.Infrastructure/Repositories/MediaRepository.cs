using Media_Manager.Core.Interfaces;
using MediaManager.Core.Models;
using MediaManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Media_Manager.Infrastructure.Repositories;

public class MediaRepository : IMediaRepository
{
    private readonly ApplicationDbContext _context;
    public MediaRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ICollection<MediaObject>> GetAllMedia()
    {
        var books = await _context.Books.ToListAsync();
        var videos = await _context.Videos.ToListAsync();
        var videoGames = await _context.VideoGames.ToListAsync();


        // var media = new List<object>();
        // media.AddRange(books);
        // media.AddRange(videos);
        // media.AddRange(videoGames);

        // return media;

        return await _context.MediaObjects.ToListAsync();
    }

    public async Task<MediaObject?> GetMediaById(int MediaId)
    {
        return await _context.MediaObjects.FindAsync(MediaId);
    }
}
