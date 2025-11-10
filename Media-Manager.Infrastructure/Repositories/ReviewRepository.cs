using System;
using Media_Manager.Core.Interfaces;
using Media_Manager.Core.Models;
using MediaManager.Core.Models;
using MediaManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Media_Manager.Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext _context;
    public ReviewRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Review> CreateAsync(Review review)
    {
        review.CreatedAt = DateTime.UtcNow;
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
        return review;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var currentReview = await _context.Reviews.FindAsync(id);
        if (currentReview == null)
        {
            return false;
        }

        _context.Reviews.Remove(currentReview);
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

    public async Task<Review> UpdateAsync(Review review)
    {
        var updatedReview = await _context.Reviews.FindAsync(review.Id);
        if (updatedReview == null)
        {
            return null;
        }

        updatedReview.Title = review.Title;
        updatedReview.Content = review.Content;
        updatedReview.EditedAt = DateTime.UtcNow;
        updatedReview.Rating = review.Rating;

        _context.Reviews.Update(updatedReview);
        await _context.SaveChangesAsync();
        return updatedReview;
    }
}
