using BIM.Application.Books.Dtos;
using BIM.Application.Common;
using BIM.Domain.Contants;
using MediatR;

namespace BIM.Application.Books.Queries.GetAllBooks;

public class GetAllBooksQuery : IRequest<IEnumerable<BookDto>>
{
    
}
