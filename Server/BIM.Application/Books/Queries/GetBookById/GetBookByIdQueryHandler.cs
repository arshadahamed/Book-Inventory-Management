
using AutoMapper;
using BIM.Application.Books.Dtos;
using BIM.Domain.Entities;
using BIM.Domain.Exceptions;
using BIM.Domain.Respositories;
using MediatR;

namespace BIM.Application.Books.Queries.GetBookById;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
{
    private readonly IMapper _mapper;
    private readonly IBooksRepository _booksRepository;

    public GetBookByIdQueryHandler(IMapper mapper, IBooksRepository booksRepository)
    {
        _mapper = mapper;
        _booksRepository = booksRepository;
    }

    public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _booksRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Book), request.Id.ToString());

        var bookDto = _mapper.Map<BookDto>(book);

        return bookDto;
    }
}

