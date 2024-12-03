using AutoMapper;
using BIM.Application.Books.Dtos;
using BIM.Application.Books.Queries.GetAllBooks;
using BIM.Application.Common;
using BIM.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BIM.Application.Books.Queries.GetAllMatching;

public class GetAllMatchingQueryHandler(ILogger<GetAllMatchingQueryHandler> logger,IMapper mapper, IBooksRepository booksRepository)
    : IRequestHandler<GetAllMatchingQuery, PagedResult<BookDto>>
{
    public async Task<PagedResult<BookDto>> Handle(GetAllMatchingQuery request, CancellationToken cancellationToken)
    {

        logger.LogInformation("Handling GetAllMatchingQuery with SearchPharse: {SearchPharse}, PageSize: {PageSize}, PageNumber: {PageNumber}, SortBy: {SortBy}, SortDirection: {SortDirection}",
            request.SearchPharse, request.PageSize, request.PageNumber, request.SortBy, request.SortDirection);

        var (books, totalCount) = await booksRepository.GetAllMatchingAsync(
            request.SearchPharse,
            request.PageSize,
            request.PageNumber,
            request.SortBy,
            request.SortDirection);

        if (books == null || !books.Any())
        {
            logger.LogInformation("No matching books found for SearchPharse: {SearchPharse}.", request.SearchPharse);
        }
        else
        {
            logger.LogInformation("Retrieved {BookCount} matching books for SearchPharse: {SearchPharse}.", books.Count(), request.SearchPharse);
        }

        var booksDtos = mapper.Map<IEnumerable<BookDto>>(books);

        logger.LogInformation("Mapped {BookCount} books to BookDto objects.", booksDtos.Count());

        var result = new PagedResult<BookDto>(booksDtos, totalCount, request.PageSize, request.PageNumber);

        logger.LogInformation("PagedResult created with TotalCount: {TotalCount}, PageSize: {PageSize}, PageNumber: {PageNumber}.", totalCount, request.PageSize, request.PageNumber);

        return result;
    }
}

