using BIM.Domain.Entities;
using BIM.Domain.Exceptions;
using BIM.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BIM.Application.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler(ILogger<DeleteBookCommandHandler> logger,
    IBooksRepository booksRepository
    ) : IRequestHandler<DeleteBookCommand>
{
    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        // Log that the request to delete a book has been received
        logger.LogInformation("Handling DeleteBookCommand for Book Id: {BookId}", request.Id);

        var book = await booksRepository.GetByIdAsync(request.Id);

        if (book == null)
        {
            logger.LogWarning("Book with Id {BookId} not found.", request.Id);
            throw new NotFoundException(nameof(Book), request.Id.ToString());
        }

        await booksRepository.Delete(book);


    }
}

