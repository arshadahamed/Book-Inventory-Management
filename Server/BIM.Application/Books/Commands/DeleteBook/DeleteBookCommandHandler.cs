using BIM.Domain.Entities;
using BIM.Domain.Exceptions;
using BIM.Domain.Respositories;
using MediatR;

namespace BIM.Application.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler(
    IBooksRepository booksRepository) : IRequestHandler<DeleteBookCommand>
{
    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await booksRepository.GetByIdAsync(request.Id);
        if (book is null)
            throw new NotFoundException(nameof(Book), request.Id.ToString());
    }
}
