using BIM.Application.Books.Dtos;
using BIM.Application.Common;
using BIM.Domain.Contants;
using MediatR;

namespace BIM.Application.Books.Queries.GetAllMatching;

public class GetAllMatchingQuery : IRequest<PagedResult<BookDto>>
{
    public string? SearchPharse { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}

