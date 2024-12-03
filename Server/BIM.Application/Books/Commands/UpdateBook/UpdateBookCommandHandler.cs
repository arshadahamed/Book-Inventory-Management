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
        // Retrieve the book from the repository by Id
        var book = await booksRepository.GetByIdAsync(request.Id);
        if (book == null)
        {
            throw new NotFoundException(nameof(Book), request.Id.ToString());
        }

        // Check authorization for updating the book
        if (!bookAuthorizationService.Authorize(book, ResourceOperation.Update))
        {
            throw new ForbidException();
        }

        // Update only the fields provided in the request
        // Null checks are unnecessary for nullable types, so only assign if not null
        if (request.Title != null)
        {
            book.Title = request.Title;
        }

        if (request.Author != null)
        {
            book.Author = request.Author;
        }

        if (request.Genre != null)
        {
            book.Genre = request.Genre;
        }

        if (request.ISBN != null)
        {
            book.ISBN = request.ISBN;
        }

        // Update in the repository (saving changes)
        await booksRepository.Update(book);
    }
}