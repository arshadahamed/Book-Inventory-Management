using BIM.Application.Books.Commands.CreateBook;
using BIM.Application.Books.Commands.DeleteBook;
using BIM.Application.Books.Commands.UpdateBook;
using BIM.Application.Books.Dtos;
using BIM.Application.Books.Queries.GetAllBooks;
using BIM.Application.Books.Queries.GetAllMatching;
using BIM.Application.Books.Queries.GetBookById;
using BIM.Application.Books.Queries.SearchBooks;
using BIM.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/books")]
public class BookController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    
    //[AllowAnonymous]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
    {
        var query = new GetAllBooksQuery();
        var books = await mediator.Send(query);
        return Ok(books);
    }

    [HttpGet("matching")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAllMatching([FromQuery] GetAllMatchingQuery query)
    {
        var books = await mediator.Send(query);
        return Ok(books);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<BookDto>> GetById([FromRoute] int id)
    {
        var book = await mediator.Send(new GetBookByIdQuery(id));
        return Ok(book);
    }

    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] UpdateBookCommand command)
    {
        command.Id = id;

        try
        {
            await mediator.Send(command);  

            return NoContent();  
        }
        catch (NotFoundException)
        {
            return NotFound();  
        }
        catch (ForbidException)
        {
            return Forbid();  
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBook([FromRoute] int id)
    {
        await mediator.Send(new DeleteBookCommand(id));
        return NoContent();
    }

    [HttpPost]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpGet("search")]
    [AllowAnonymous]
    public async Task<IActionResult> SearchBooks([FromQuery] string? keywords, [FromQuery] string? author, [FromQuery] string? genre)
    {
        var query = new SearchBooksQuery
        {
            Keywords = keywords,
            Author = author,
            Genre = genre
        };

        var result = await mediator.Send(query);
        return Ok(result);
    }
}
