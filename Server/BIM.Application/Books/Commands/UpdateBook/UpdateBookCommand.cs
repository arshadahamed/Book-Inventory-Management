using MediatR;

namespace BIM.Application.Books.Commands.UpdateBook;

public class UpdateBookCommand : IRequest
{
    public int Id { get; set; }
    public string? Title { get; set; } 
    public string? Author { get; set; }
    public string? Genre { get; set; }
    public string? ISBN { get; set; } 

}
