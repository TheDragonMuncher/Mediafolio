using MediaManager.Core.Interfaces;
using MediaManager.Core.Models;
using MediaManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MediaManager.Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext _context;

    public ReviewRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Review?> CreateAsync(Review review)
    {
        var media = await _context.MediaObjects.FindAsync(review.MediaObjectId);
        if (media == null)
        {
            return null;
        }

        review.CreatedAt = DateTime.UtcNow;
        _context.Reviews.Add(review);
        
        await _context.SaveChangesAsync();
        return review;

    }

    public async Task<bool> DeleteAsync(int id)
    {
        var currentReview = await _context.Reviews.FindAsync(id);
        if (currentReview == null)
            return false;

        var mediaObject = await _context.MediaObjects.FindAsync(currentReview.MediaObjectId);

        if (mediaObject == null)
        {
            _context.Reviews.Remove(currentReview);
            return true; 
        }

        _context.MediaObjects.Remove(mediaObject);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<ICollection<Review>> GetAllAsync()
    {
        return await _context.Reviews.ToListAsync();
    }

    public async Task<Review?> GetByIdAsync(int id)
    {
        return await _context.Reviews.FindAsync(id);
    }

    public async Task<Review?> UpdateAsync(Review review)
    {
        var existingReview = await _context.Reviews.FindAsync(review.Id);
        if (existingReview == null)
        {
            return null;
        }

        existingReview.Title = review.Title;
        existingReview.Content = review.Content;
        existingReview.Rating = review.Rating;
        existingReview.UpdatedAt = DateTime.UtcNow;
        
        await _context.SaveChangesAsync();
        return existingReview;
    }
}