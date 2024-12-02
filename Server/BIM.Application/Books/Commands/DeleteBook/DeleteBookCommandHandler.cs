using BIM.Domain.Contants;
using BIM.Domain.Entities;
using BIM.Domain.Exceptions;
using BIM.Domain.Interfaces;
using BIM.Domain.Respositories;
using MediatR;

namespace BIM.Application.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler(
    IBooksRepository booksRepository,
    IBookAuthorizationService bookAuthorizationService) : IRequestHandler<DeleteBookCommand>
{
    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await booksRepository.GetByIdAsync(request.Id);
        if (book is null)
            throw new NotFoundException(nameof(Book), request.Id.ToString());

        if (!bookAuthorizationService.Authorize(book, ResourceOperation.Update))
            throw new ForbidException();

        await booksRepository.Delete(book);
    }
}
