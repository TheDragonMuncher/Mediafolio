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
        baseUrl = config["Media-Manager.API:Base Url"] ?? "https://media-manager-a0dqheccg5fqg0dq.canadacentral-01.azurewebsites.net/api/";
        baseUrl += "book";
    }
    public Task<Book> CreateBook(CreateBookDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteBook(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Book>> GetallBooks()
    {
        try
        {
            var response = await _httpClient.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            List<Mediafolio.Models.Book>? result = JsonSerializer.Deserialize<List<Mediafolio.Models.Book>>(content, new JsonSerializerOptions {PropertyNameCaseInsensitive = true});

            if(result == null)
            {
                return new List<Mediafolio.Models.Book>();
            }
            return result;
        } 
        catch(HttpRequestException e)
        {
            throw new InvalidOperationException("Failed to get Books results. Please check your internet connection.",e);
        }
        catch(JsonException e)
        {
            throw new InvalidOperationException("Failed to process Books results.",e);
        }
        catch(Exception)
        {
            throw;
        }

        // return new List<Book>() { new Book() {Title = "Hello World", AuthorName = "Joseph Desire",  Summary = "This is my summary"}, new Book() {Title = "The gand of Four", AuthorName = "Uncle Bob",  Summary = "This is my summary"}};
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
