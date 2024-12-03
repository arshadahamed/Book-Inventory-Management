using BIM.Application.Books.Dtos;
using MediatR;

namespace BIM.Application.Books.Queries.SearchBooks;

public class SearchBooksQuery : IRequest<IEnumerable<BookDto>>
{
    public string? Keywords { get; set; }
    public string? Author { get; set; }
    public string? Genre { get; set; }
}
