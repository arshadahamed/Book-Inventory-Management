using BIM.Domain.Contants;
using BIM.Domain.Entities;
using BIM.Domain.Exceptions;
using BIM.Domain.Interfaces;
using BIM.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BIM.Application.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler(ILogger<DeleteBookCommandHandler> logger,
    IBooksRepository booksRepository,
    IBookAuthorizationService bookAuthorizationService) : IRequestHandler<DeleteBookCommand>
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

        // Log that the book was found and authorization check is in progress
        logger.LogInformation("Found Book with Id {BookId}, checking authorization to delete.", request.Id);

        if (!bookAuthorizationService.Authorize(book, ResourceOperation.Update))
        {
            logger.LogWarning("Unauthorized attempt to delete Book with Id {BookId}.", request.Id);
            throw new ForbidException();
        }

        // Log the successful authorization and deletion process
        logger.LogInformation("Authorized deletion of Book with Id {BookId}. Proceeding to delete.", request.Id);

        // Delete the book from the repository
        await booksRepository.Delete(book);

        // Log successful deletion
        logger.LogInformation("Book with Id {BookId} deleted successfully.", request.Id);
    }
}

