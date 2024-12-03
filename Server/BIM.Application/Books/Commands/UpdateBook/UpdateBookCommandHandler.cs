using AutoMapper;
using BIM.Domain.Contants;
using BIM.Domain.Entities;
using BIM.Domain.Exceptions;
using BIM.Domain.Interfaces;
using BIM.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BIM.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler(ILogger<UpdateBookCommandHandler> logger,
    IBooksRepository booksRepository,
    IBookAuthorizationService bookAuthorizationService,
    IMapper mapper) : IRequestHandler<UpdateBookCommand>
{
    public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {

        logger.LogInformation("Handling UpdateBookCommand for Book Id: {BookId}", request.Id);

        var book = await booksRepository.GetByIdAsync(request.Id);
        if (book == null)
        {
            logger.LogWarning("Book with Id {BookId} not found.", request.Id);
            throw new NotFoundException(nameof(Book), request.Id.ToString());
        }


        logger.LogInformation("Found Book with Id {BookId}, checking authorization to update.", request.Id);

        if (!bookAuthorizationService.Authorize(book, ResourceOperation.Update))
        {
            logger.LogWarning("Unauthorized attempt to update Book with Id {BookId}.", request.Id);
            throw new ForbidException();
        }


        logger.LogInformation("Authorized update for Book with Id {BookId}. Updating fields.", request.Id);


        if (request.Title != null)
        {
            logger.LogInformation("Updating Title for Book with Id {BookId} to {Title}", request.Id, request.Title);
            book.Title = request.Title;
        }

        if (request.Author != null)
        {
            logger.LogInformation("Updating Author for Book with Id {BookId} to {Author}", request.Id, request.Author);
            book.Author = request.Author;
        }

        if (request.Genre != null)
        {
            logger.LogInformation("Updating Genre for Book with Id {BookId} to {Genre}", request.Id, request.Genre);
            book.Genre = request.Genre;
        }

        if (request.ISBN != null)
        {
            logger.LogInformation("Updating ISBN for Book with Id {BookId} to {ISBN}", request.Id, request.ISBN);
            book.ISBN = request.ISBN;
        }


        await booksRepository.Update(book);


        logger.LogInformation("Book with Id {BookId} successfully updated.", request.Id);
    }
}