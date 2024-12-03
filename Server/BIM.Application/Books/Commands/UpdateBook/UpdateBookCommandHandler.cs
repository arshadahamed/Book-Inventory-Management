using AutoMapper;
using BIM.Domain.Contants;
using BIM.Domain.Entities;
using BIM.Domain.Exceptions;
using BIM.Domain.Interfaces;
using BIM.Domain.Respositories;
using MediatR;

namespace BIM.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler(
    IBooksRepository booksRepository,
    IBookAuthorizationService bookAuthorizationService,
    IMapper mapper) : IRequestHandler<UpdateBookCommand>
{
    public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var book = await booksRepository.GetByIdAsync(request.Id);
            if (book is null)
            {
                //logger.LogError($"Book with Id {request.Id} not found.");
                throw new NotFoundException(nameof(Book), request.Id.ToString());
            }

            if (!bookAuthorizationService.Authorize(book, ResourceOperation.Update))
            {
                //logger.LogWarning($"Unauthorized attempt to update book with Id {request.Id}.");
                throw new ForbidException();
            }

            mapper.Map(request, book);

            await booksRepository.Update(book);  // Pass the book to the update method
            //logger.LogInformation($"Book with Id {request.Id} successfully updated.");
        }
        catch (Exception ex)
        {
            //logger.LogError(ex, "Error while updating the book.");
            throw ;  // Re-throw the exception after logging it
        }
    }
}
