using AutoMapper;
using BIM.Application.Books.Dtos;
using BIM.Domain.Respositories;
using MediatR;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading;
using System.Threading.Tasks;

namespace BIM.Application.Books.Queries.SearchBooks
{
    public class SearchBooksQueryHandler(IMapper mapper, IBooksRepository booksRepository) : IRequestHandler<SearchBooksQuery, IEnumerable<BookDto>>
    {

        public async Task<IEnumerable<BookDto>> Handle(SearchBooksQuery request, CancellationToken cancellationToken)
        {
          
            var books = await booksRepository.SearchBooksAsync(request.Keywords, request.Author, request.Genre);

            // Map the list of Book entities to BookDto
            var bookDtos = mapper.Map<IEnumerable<BookDto>>(books);

            return bookDtos;
        }
    }
}
