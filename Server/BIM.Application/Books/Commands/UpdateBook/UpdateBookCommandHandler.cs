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
        var book = await booksRepository.GetByIdAsync(request.Id);
        if (book is null)
            throw new NotFoundException(nameof(Book), request.Id.ToString());

        if (!bookAuthorizationService.Authorize(book, ResourceOperation.Update))
            throw new ForbidException();

        mapper.Map(request, book);

        await booksRepository.Update();
    }
}
