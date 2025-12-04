using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediafolio.Components.Pages;
using Mediafolio.DTOs;
using Mediafolio.Models;

namespace Mediafolio.Services;

public interface IVideoService
{
    Task<ICollection<VideoResponse>> GetAllVideosAsync();

    Task<VideoResponse?> GetVideoIdAsync(int id);
    Task<VideoResponse> CreateVideoAsync(CreateVideoDto videoDto);
    Task<VideoResponse?> UpdateVideoAsync(int id, UpdateVideoDto videoDto); 
    Task<VideoResponse?> DeleteVideoAsync(int id);






}