using System;
using MediaManager.Core.DTOs;
using MediaManager.Core.Models;

namespace Media_Manager.Core.Converters;

public static class BookConverter
{
    public static CreateBookDto ToCreateBookDto(this Book book)
    {
        return new CreateBookDto()
        {
            Title = book.Title,
            AuthorName = book.AuthorName,
            Genre = book.Genre,
            ISBN = book.ISBN,
            NumberOfPages = book.NumberOfPages,
            PublicationYear = book.PublicationYear
        };
    }
    public static Book FromBookDto(this CreateBookDto dto)
    {
        return new Book()
        {
            Title = dto.Title,
            AuthorName = dto.AuthorName,
            Genre = dto.Genre,
            ISBN = dto.ISBN,
            NumberOfPages = dto.NumberOfPages,
            PublicationYear = dto.PublicationYear
        };
    }
    public static UpdateBookDto ToUpdateBookDto(this Book book)
    {
        return new UpdateBookDto()
        {
            Title = book.Title,
            AuthorName = book.AuthorName,
            Genre = book.Genre,
            ISBN = book.ISBN,
            NumberOfPages = book.NumberOfPages,
            PublicationYear = book.PublicationYear
        };
    }

    public static Book FromUpdateBookDto(this UpdateBookDto dto)
    {
        return new Book()
        {
            Title = dto.Title,
            AuthorName = dto.AuthorName,
            Genre = dto.Genre,
            ISBN = dto.ISBN,
            NumberOfPages = dto.NumberOfPages,
            PublicationYear = dto.PublicationYear
        };
    }
}