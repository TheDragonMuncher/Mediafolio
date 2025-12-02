using Media_Manager.Core.DTOs;
using MediaManager.Core.Models;

namespace Media_Manager.Core.Converters;

public static class ReviewConverter
{
    public static Review FromCreateReviewDto(this CreateReviewDto dto)
    {
        return new Review()
        {
            Title = dto.Title,
            Content = dto.Content,
            Rating = dto.Rating
        };
    }

    public static CreateReviewDto CreateReviewDto(this Review dto)
    {
        return new CreateReviewDto()
        {
            Title = dto.Title,
            Content = dto.Content,
            Rating = dto.Rating
        };   
    }

    public static Review FromUpdateReviewDto(this UpdateReviewDto dto)
    {
        return new Review()
        {
            Title = dto.Title,
            Content = dto.Content,
            Rating = dto.Rating
        };
    }

    public static UpdateReviewDto UpdateReviewDto(this Review review)
    {
        return new UpdateReviewDto()
        {
            Title = review.Title,
            Content = review.Content,
            Rating = review.Rating
        };
    } 
}
