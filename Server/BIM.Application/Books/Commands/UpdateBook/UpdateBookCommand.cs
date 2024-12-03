using MediatR;

namespace BIM.Application.Books.Commands.UpdateBook;

public class UpdateBookCommand : IRequest
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Author { get; set; } = default!;
    public string Genre { get; set; } = default!;
    public string ISBN { get; set; } = default!;

}
