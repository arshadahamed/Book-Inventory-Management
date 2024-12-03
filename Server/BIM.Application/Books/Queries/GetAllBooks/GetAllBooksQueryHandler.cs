using AutoMapper;
using BIM.Application.Books.Dtos;
using BIM.Application.Common;
using BIM.Domain.Entities;
using BIM.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BIM.Application.Books.Queries.GetAllBooks;

public class GetAllBooksQueryHandler(IMapper mapper, IBooksRepository booksRepository)
    : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
{
    public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await booksRepository.GetAllAsync();
        var bookDtos = mapper.Map<IEnumerable<BookDto>>(books);

        return bookDtos;
    }
}
