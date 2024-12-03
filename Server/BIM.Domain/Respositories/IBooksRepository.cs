using BIM.Domain.Entities;
using BIM.Domain.Contants;
using System.Threading.Tasks;

namespace BIM.Domain.Respositories;

public interface IBooksRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<IEnumerable<Book>> SearchBooksAsync(string? keywords, string? author, string? genre);
    Task<(IEnumerable<Book>, int)> GetAllMatchingAsync(string? searchPharse, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection);
    Task<Book?> GetByIdAsync(int id);
    Task<int> Create(Book book);
    Task Delete(Book book);
    Task Update();
}
