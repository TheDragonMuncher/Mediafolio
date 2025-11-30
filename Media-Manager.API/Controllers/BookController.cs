using MediaManager.Core.DTOs;
using MediaManager.Core.Interfaces;
using MediaManager.Core.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MediaManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    
    private readonly IBookRepository _repository;

    public BookController(IBookRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetAll()
    {
        var books = await _repository.GetAllAsync();
        return Ok(books);
    }



    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetById(int id)
    {
        var book = await _repository.GetByIdAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);

    }

    [HttpPost("{userId}")]
    public async Task<ActionResult<Book>> CreatePost([FromBody] CreateBookDto dto, string userId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); 
        }

        var book = new Book
        {
          
          Title = dto.Title,
          AuthorName = dto.AuthorName,
          Summary = dto.Summary,
          Genre = dto.Genre,
          ISBN = dto.ISBN,
          NumberOfPages = dto.NumberOfPages,
          PublicationYear = dto.PublicationYear,
          CoverImageURL = dto.CoverImageURL
        };

        var createdBook = await _repository.CreateAsync(book, userId);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdBook.Id },
            createdBook
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateBookDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var book = new Book
        {
            AuthorName = dto.AuthorName,
            Title = dto.Title,
            Summary = dto.Summary,
            Genre = dto.Genre,
            NumberOfPages = dto.NumberOfPages,
            PublicationYear = dto.PublicationYear,
            UpdatedAt = dto.UpdatedAt
        };

        var updatedBook = await _repository.UpdateAsync(book);
        if (updatedBook == null)
        {
            return NotFound(new { message = $"Book with id: {id} not found" });
        }

        return Ok(updatedBook);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchBook(int id, [FromBody] JsonPatchDocument<Book> patchDoc)
    {
        if (patchDoc == null)
        {
            return BadRequest(new { message = "Patch document is null" });
        }

        var book = await _repository.GetByIdAsync(id);
        if (book == null)
        {
            return NotFound(new { message = $"Book with id: {id} not found" });
        }

        patchDoc.ApplyTo(book, ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        book.UpdatedAt = DateTime.UtcNow;
        await _repository.UpdateAsync(book);
        return Ok(book);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _repository.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound(new { message = $"Book with id: {id} not found" });
        }
        return NoContent();
    }

}