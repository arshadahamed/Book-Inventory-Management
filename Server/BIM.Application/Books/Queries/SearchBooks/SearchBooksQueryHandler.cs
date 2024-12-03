using AutoMapper;
using BIM.Application.Books.Dtos;
using BIM.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading;
using System.Threading.Tasks;

namespace BIM.Application.Books.Queries.SearchBooks
{
    public class SearchBooksQueryHandler(ILogger<SearchBooksQueryHandler> logger,IMapper mapper, IBooksRepository booksRepository) : IRequestHandler<SearchBooksQuery, IEnumerable<BookDto>>
    {

        public async Task<IEnumerable<BookDto>> Handle(SearchBooksQuery request, CancellationToken cancellationToken)
        {

            logger.LogInformation("Handling SearchBooksQuery with Keywords: {Keywords}, Author: {Author}, Genre: {Genre}",
                request.Keywords, request.Author, request.Genre);

            var books = await booksRepository.SearchBooksAsync(request.Keywords, request.Author, request.Genre);

            if (books == null || !books.Any())
            {
                logger.LogInformation("No books found matching the search criteria.");
                return Enumerable.Empty<BookDto>();
            }

            logger.LogInformation("{BookCount} books found matching the search criteria.", books.Count());

            var bookDtos = mapper.Map<IEnumerable<BookDto>>(books);

            return bookDtos;
        }
    }
}
