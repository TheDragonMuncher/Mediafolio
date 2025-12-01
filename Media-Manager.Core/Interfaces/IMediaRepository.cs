using System;
using MediaManager.Core.Models;

namespace Media_Manager.Core.Interfaces;

public interface IMediaRepository
{
    Task<ICollection<object>> GetAllMedia();
    Task<MediaObject?> GetMediaById(int MediaId);

}
