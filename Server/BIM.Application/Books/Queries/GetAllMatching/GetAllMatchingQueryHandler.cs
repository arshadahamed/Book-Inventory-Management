using AutoMapper;
using BIM.Application.Books.Dtos;
using BIM.Application.Books.Queries.GetAllBooks;
using BIM.Application.Common;
using BIM.Domain.Respositories;
using MediatR;

namespace BIM.Application.Books.Queries.GetAllMatching;

public class GetAllMatchingQueryHandler(IMapper mapper, IBooksRepository booksRepository)
    : IRequestHandler<GetAllMatchingQuery, PagedResult<BookDto>>
{
    public async Task<PagedResult<BookDto>> Handle(GetAllMatchingQuery request, CancellationToken cancellationToken)
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

