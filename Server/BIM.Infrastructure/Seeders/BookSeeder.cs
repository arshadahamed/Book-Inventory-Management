using BIM.Domain.Entities;
using BIM.Infrastructure.Persistence;

namespace BIM.Infrastructure.Seeders;

internal class BookSeeder(BIMDbContext dbContext) : IBookSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Books.Any())
            {
                var books = GetBooks();
                await dbContext.Books.AddRangeAsync(books);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Book> GetBooks()
    {
        List<Book> books = new()
        {
            new Book
            {
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                Genre = "Classic Fiction",
                ISBN = "9780743273565",
                PublishedDate = new DateTime(1925, 4, 10),
                Price = 1500,
                Quantity = 50
            },
            new Book
            {
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                Genre = "Classic Fiction",
                ISBN = "9780061120084",
                PublishedDate = new DateTime(1960, 7, 11),
                Price = 1200,
                Quantity = 75
            }
        };
        return books;
    }
}
