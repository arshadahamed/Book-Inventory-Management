
using AutoMapper;
using BIM.Application.Books.Dtos;
using BIM.Domain.Entities;
using BIM.Domain.Exceptions;
using BIM.Domain.Respositories;
using MediatR;

namespace BIM.Application.Books.Queries.GetBookById;

public class GetBookByIdQueryHandler(IMapper mapper, IBooksRepository booksRepository)
     : IRequestHandler<GetBookByIdQuery, BookDto>
{
    public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await booksRepository.GetByIdAsync(request.Id)
             ?? throw new NotFoundException(nameof(Book), request.Id.ToString());

        var bookDto = mapper.Map<BookDto>(book);

        return bookDto;
    }
}
