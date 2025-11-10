using System;

namespace Media_Manager.Core.DTOs;

public class CreateReviewDto
{
    public class ReviewCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}
