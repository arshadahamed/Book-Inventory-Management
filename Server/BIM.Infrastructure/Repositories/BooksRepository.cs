using BIM.Domain.Entities;
using BIM.Domain.Respositories;
using BIM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

    async Task<Book?> GetByIdAsync(int id)
    {
        var book = await dbContext.Books
                .FirstOrDefaultAsync(x => x.Id == id);
        return book;
    }

    public Task Update()
     => dbContext.SaveChangesAsync();
}
