
using AutoMapper;
using BIM.Application.Books.Dtos;
using BIM.Domain.Entities;
using BIM.Domain.Exceptions;
using BIM.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BIM.Application.Books.Queries.GetBookById;

public class GetBookByIdQueryHandler(ILogger<GetBookByIdQueryHandler> logger,IMapper mapper,IBooksRepository booksRepository) : IRequestHandler<GetBookByIdQuery, BookDto>
{
    public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling GetBookByIdQuery for BookId: {BookId}", request.Id);

        var book = await booksRepository.GetByIdAsync(request.Id);

        if (book == null)
        {
            logger.LogWarning("Book with Id {BookId} not found.", request.Id);
            throw new NotFoundException(nameof(Book), request.Id.ToString());
        }

        var bookDto = mapper.Map<BookDto>(book);

        logger.LogInformation("Successfully retrieved and mapped Book with Id {BookId} to BookDto.", request.Id);

        return bookDto;
    }
}

