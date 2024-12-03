using AutoMapper;
using BIM.Domain.Entities;
using BIM.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BIM.Application.Books.Commands.CreateBook;

public class CreateBookCommandHandler(ILogger<CreateBookCommandHandler> logger,IMapper mapper, IBooksRepository booksRepository) : IRequestHandler<CreateBookCommand, int>
{
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        // Log that the request to create a book has been received
        logger.LogInformation("Handling CreateBookCommand for Title: {Title}, Author: {Author}", request.Title, request.Author);

        try
        {
            var book = mapper.Map<Book>(request);
            logger.LogInformation("Mapped Book entity: {@Book}", book);
            int id = await booksRepository.Create(book);

            logger.LogInformation("Book created successfully with Id: {BookId}", id);

            return id;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while creating the book.");
            throw; 
        }
    }
}
