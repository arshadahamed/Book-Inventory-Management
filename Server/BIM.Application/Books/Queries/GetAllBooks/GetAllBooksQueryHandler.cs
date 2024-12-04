using AutoMapper;
using BIM.Application.Books.Dtos;
using BIM.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BIM.Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
    {
        private readonly ILogger<GetAllBooksQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IBooksRepository _booksRepository;

        // Constructor
        public GetAllBooksQueryHandler(
            ILogger<GetAllBooksQueryHandler> logger,
            IMapper mapper,
            IBooksRepository booksRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _booksRepository = booksRepository;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            // Fetch all books
            var books = await _booksRepository.GetAllAsync();

            // Log if no books are found
            if (books == null || !books.Any())
            {
                _logger.LogInformation("No books found.");
                return Enumerable.Empty<BookDto>(); // Return an empty collection if no books found
            }
            else
            {
                _logger.LogInformation("Retrieved {BookCount} books.", books.Count());
            }

            // Map to DTO
            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);

            // Log mapping
            _logger.LogInformation("Mapped {BookCount} books to BookDto objects.", bookDtos.Count());

            return bookDtos;
        }
    }
}
