using AutoMapper;
using BIM.Domain.Entities;
using BIM.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BIM.Application.Books.Commands.CreateBook;

public class CreateBookCommandHandler(IMapper mapper, IBooksRepository booksRepository) : IRequestHandler<CreateBookCommand, int>
{
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = mapper.Map<Book>(request);
        int id = await booksRepository.Create(book);
        return id;
    }
}
