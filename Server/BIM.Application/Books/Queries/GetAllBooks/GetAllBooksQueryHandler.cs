using AutoMapper;
using BIM.Application.Books.Dtos;
using BIM.Application.Common;
using BIM.Domain.Entities;
using BIM.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BIM.Application.Books.Queries.GetAllBooks;

public class GetAllBooksQueryHandler(ILogger<GetAllBooksQueryHandler> logger,IMapper mapper, IBooksRepository booksRepository)
    : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
{
    public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {

        var books = await booksRepository.GetAllAsync();

        if (books == null || !books.Any())
        {

            logger.LogInformation("No books found.");
        }
        else
        {
            logger.LogInformation("Retrieved {BookCount} books.", books.Count());
        }

        var bookDtos = mapper.Map<IEnumerable<BookDto>>(books);


        logger.LogInformation("Mapped {BookCount} books to BookDto objects.", bookDtos.Count());


        return bookDtos;
    }
}
