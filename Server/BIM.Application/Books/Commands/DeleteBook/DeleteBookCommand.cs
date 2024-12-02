using MediatR;

namespace BIM.Application.Books.Commands.DeleteBook;

public class DeleteBookCommand(int id) : IRequest
{
    public int Id { get; } = id;
}
