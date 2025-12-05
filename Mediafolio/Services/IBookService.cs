using System;
using Mediafolio.DTOs;
using Mediafolio.Models;


namespace Mediafolio.Services;

public interface IBookService
{
    Task<List<Book>> GetallBooks();
    Task<Book?> GetBookById(int id);
    Task<Book> CreateBook(CreateBookDto dto);
    Task<Book> UpdateBook(int id, UpdateBookDto dto);
    Task<bool> DeleteBook(int id);
}
