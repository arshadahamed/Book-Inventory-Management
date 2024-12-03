using BIM.Domain.Contants;
using BIM.Domain.Entities;
using BIM.Domain.Respositories;
using BIM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BIM.Infrastructure.Repositories;

internal class BooksRepository(BIMDbContext dbContext) : IBooksRepository

{
    public async Task<int> Create(Book book)
    {
       dbContext.Books.Add(book);
       await dbContext.SaveChangesAsync();
       return book.Id;
        
    }

    public async Task Delete(Book book)
    {
        dbContext.Remove(book);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        var books = await dbContext.Books.ToListAsync();
        return books;
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        var book = await dbContext.Books
                .FirstOrDefaultAsync(x => x.Id == id);
        return book;
    }

    public Task Update()
     => dbContext.SaveChangesAsync();

    public async Task<(IEnumerable<Book>, int)> GetAllMatchingAsync(string? searchPharse, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection)
    {
            var searchPharseLower = searchPharse?.ToLower();

            var baseQuery = dbContext
                 .Books
                 .Where(r => searchPharseLower == null || (r.Title.ToLower().Contains(searchPharseLower)
                                                        || r.Genre.ToLower().Contains(searchPharseLower)
                                                        || r.Author.ToLower().Contains(searchPharseLower)));

            var totalCount = await baseQuery.CountAsync();

            if (sortBy != null)
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Book, object>>>
            {
                { nameof(Book.Title),r => r.Title },
                { nameof(Book.Genre),r => r.Genre },
                { nameof(Book.Author),r => r.Author },
            };
                var selectedColumn = columnsSelector[sortBy];

                baseQuery = sortDirection == SortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var restaurants = await baseQuery
                 .Skip(pageSize * (pageNumber - 1))
                 .Take(pageSize)
                 .ToListAsync();
            return (restaurants, totalCount);
        }

    public async Task<IEnumerable<Book>> SearchBooksAsync(string? keywords, string? author, string? genre)
    {
        var query = dbContext.Books.AsQueryable();

        if (!string.IsNullOrEmpty(keywords))
        {
            var keywordsPattern = $"%{keywords}%"; // Create SQL LIKE pattern
            query = query.Where(b =>
                EF.Functions.Like(b.Title, keywordsPattern) ||
                EF.Functions.Like(b.Author, keywordsPattern) ||
                EF.Functions.Like(b.Genre, keywordsPattern));
        }

        if (!string.IsNullOrEmpty(author))
        {
            query = query.Where(b => EF.Functions.Like(b.Author, $"%{author}%"));
        }

        if (!string.IsNullOrEmpty(genre))
        {
            query = query.Where(b => EF.Functions.Like(b.Genre, $"%{genre}%"));
        }

        return await query.ToListAsync();
    }
}
