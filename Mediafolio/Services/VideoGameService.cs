using MediaManager.Core.Models;
using MediaManager.Core.DTOs;
using System.Text.Json;

namespace Mediafolio.Services;

public class VideoGameService : IVideoGameService
{
    readonly HttpClient _httpClient;
    readonly string baseUrl;

    public VideoGameService(HttpClient client, IConfiguration config)
    {
        _httpClient = client;
        baseUrl = config["Media-Manager.API:Base Url"] ?? "https://media-manager-a0dqheccg5fqg0dq.canadacentral-01.azurewebsites.net/api";
        baseUrl += "/VideoGame";
    }

    public async Task<VideoGame> CreateGame(CreateVideoGameDto dto)
    {
        try
        {
            var content = JsonSerializer.Serialize(dto);
            var response = await _httpClient.PostAsJsonAsync(baseUrl, content);
            response.EnsureSuccessStatusCode();

            var responseContent = JsonSerializer.Deserialize<VideoGame>(await response.Content.ReadAsStringAsync());
            if(responseContent == null)
            {
                return null;
            }
            return responseContent;
        }
        catch(HttpRequestException e)
        {
            throw new InvalidOperationException("Failed to get video game results. Please check your internet connection.",e);
        }
        catch(JsonException e)
        {
            throw new InvalidOperationException("Failed to process video game results.",e);
        }
        catch(Exception)
        {
            throw;
        }
    }

    public async Task<bool> DeleteGame(int id)
    {
        try
        {
            if(id <= 0)
            {
                return false;
            }
            var url = $"{baseUrl}/{id}";
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();

            if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        } 
        catch(HttpRequestException e)
        {
            throw new InvalidOperationException("Failed to get video game results. Please check your internet connection.",e);
        }
        catch(Exception)
        {
            throw;
        }
    }

    public async Task<ICollection<VideoGame>> GetAllGames()
    {
        try
        {
            var response = await _httpClient.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ICollection<VideoGame>>(content);

            if(result == null)
            {
                return new List<VideoGame>();
            }
            return result;
        } 
        catch(HttpRequestException e)
        {
            throw new InvalidOperationException("Failed to get video game results. Please check your internet connection.",e);
        }
        catch(JsonException e)
        {
            throw new InvalidOperationException("Failed to process video game results.",e);
        }
        catch(Exception)
        {
            throw;
        }
    }

    public async Task<VideoGame?> GetGameById(int id)
    {
        try
        {
            if(id <= 0)
            {
                return null;
            }
            var url = $"{baseUrl}/{id}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<VideoGame>(content);

            return result;
        } 
        catch(HttpRequestException e)
        {
            throw new InvalidOperationException("Failed to get video game results. Please check your internet connection.",e);
        }
        catch(JsonException e)
        {
            throw new InvalidOperationException("Failed to process video game results.",e);
        }
        catch(Exception)
        {
            throw;
        }
    }

    public async Task<VideoGame> UpdateGame(int id, UpdateVideoGameDto dto)
    {
        try
        {
            if(id <= 0)
            {
                return null;
            }
            var url = $"{baseUrl}/{id}";
            var response = await _httpClient.PutAsJsonAsync(url, JsonSerializer.Serialize(dto));
            response.EnsureSuccessStatusCode();

            var responseContent = JsonSerializer.Deserialize<VideoGame>(await response.Content.ReadAsStringAsync());
            if(responseContent == null)
            {
                return null;
            }
            return responseContent;
        } 
        catch(HttpRequestException e)
        {
            throw new InvalidOperationException("Failed to get video game results. Please check your internet connection.",e);
        }
        catch(JsonException e)
        {
            throw new InvalidOperationException("Failed to process video game results.",e);
        }
        catch(Exception)
        {
            throw;
        }
    }
}