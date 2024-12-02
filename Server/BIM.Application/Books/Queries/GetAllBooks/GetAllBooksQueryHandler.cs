using AutoMapper;
using BIM.Application.Books.Dtos;
using BIM.Application.Common;
using BIM.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BIM.Application.Books.Queries.GetAllBooks;

public class GetAllBooksQueryHandler(IMapper mapper, IBooksRepository booksRepository)
    : IRequestHandler<GetAllBooksQuery, PagedResult<BookDto>>
{
    public async Task<PagedResult<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
       
        var (books, totalCount) = await booksRepository.GetAllMatchingAsync(request.SearchPharse,
            request.PageSize,
            request.PageNumber,
            request.SortBy,
            request.SortDirection);

        var booksDtos = mapper.Map<IEnumerable<BookDto>>(books);

        var result = new PagedResult<BookDto>(booksDtos, totalCount, request.PageSize, request.PageNumber);

        return result!;
    }
}
