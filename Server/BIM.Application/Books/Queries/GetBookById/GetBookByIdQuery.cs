using BIM.Application.Books.Dtos;
using MediatR;

namespace BIM.Application.Books.Queries.GetBookById;

public class GetBookByIdQuery(int id) : IRequest<BookDto>
{
    public int Id { get; set; } = id;
}
