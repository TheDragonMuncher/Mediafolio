using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Mediafolio.DTOs;
using Mediafolio.Models;

namespace Mediafolio.Services;
    public class VideoService : IVideoService
    {

        private readonly HttpClient _httpClient;
        private readonly string _apiUrl; 

        public VideoService( HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiUrl = configuration["MediaFolio:ApiUrl"] ?? "https://media-manager-a0dqheccg5fqg0dq.canadacentral-01.azurewebsites.net/";
    }

    public Task<VideoResponse> CreateVideoAsync(CreateVideoDto videoDto)
    {
        throw new NotImplementedException();
    }

    public Task<VideoResponse?> DeleteVideoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<VideoResponse>> GetAllVideosAsync()
    {
        var url = _apiUrl; 
        var response = await _httpClient.GetAsync(url); 

        response.EnsureSuccessStatusCode(); 

        var content = await response.Content.ReadAsStringAsync(); 

        var pageLoadResponse = JsonSerializer.Deserialize<VideoResponse>
        (
            content, 
            new JsonSerializerOptions {PropertyNameCaseInsensitive = true}
        );

        if (pageLoadResponse != null)
        {
            return pageLoadResponse; 
        }




    }

    public Task<VideoResponse?> GetVideoIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<VideoResponse?> UpdateVideoAsync(int id, UpdateVideoDto videoDto)
    {
        throw new NotImplementedException();
    }
}
