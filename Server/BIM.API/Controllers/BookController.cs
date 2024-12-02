using BIM.Application.Books.Commands.CreateBook;
using BIM.Application.Books.Commands.DeleteBook;
using BIM.Application.Books.Commands.UpdateBook;
using BIM.Application.Books.Dtos;
using BIM.Application.Books.Queries.GetAllBooks;
using BIM.Application.Books.Queries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BIM.API.Controllers;

[ApiController]
[Route("api/books")]
public class BookController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAll([FromQuery] GetAllBooksQuery query)
    {
        var books = await mediator.Send(query);
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetById([FromRoute] int id)
    {
        var book = await mediator.Send(new GetBookByIdQuery(id));
        return Ok(book);
    }



    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBook([FromRoute] int id, UpdateBookCommand command)
    {
        command.Id = id;
        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBook([FromRoute] int id)
    {
        await mediator.Send(new DeleteBookCommand(id));

        return NoContent();
    }


    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}
