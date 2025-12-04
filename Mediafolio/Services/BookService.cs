using System;
using Mediafolio.DTOs;
using Mediafolio.Models;
using System.Text.Json;

namespace Mediafolio.Services;

public class BookService : IBookService
{

    readonly HttpClient _httpClient;
    readonly string baseUrl;

    public BookService(HttpClient client, IConfiguration config)
    {
        _httpClient = client;
        baseUrl = config["Media-Manager.API:Base Url"] ?? "https://media-manager-a0dqheccg5fqg0dq.canadacentral-01.azurewebsites.net/api";
        baseUrl += "/VideoGame";
    }
    public Task<Book> CreateBook(CreateBookDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteBook(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Book>> GetallBooks()
    {
        throw new NotImplementedException();
    }

    public async Task<Book?> GetBookById(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Exception: {e}");
        }

        throw new NotImplementedException();
    }

    public Task<Book> UpdateBook(int id, UpdateBookDto dto)
    {
        throw new NotImplementedException();
    }
}
