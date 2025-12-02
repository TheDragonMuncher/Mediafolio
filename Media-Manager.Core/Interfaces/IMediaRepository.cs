using MediaManager.Core.Models;

namespace Media_Manager.Core.Interfaces;

public interface IMediaRepository
{
    Task<ICollection<MediaObject>> GetAllMedia();
    Task<MediaObject?> GetMediaById(int MediaId);

}
