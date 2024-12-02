using BIM.Domain.Entities;
using BIM.Domain.Contants;

namespace BIM.Domain.Respositories;

public interface IBooksRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<(IEnumerable<Book>, int)> GetAllMatchingAsync(string? searchPharse, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection);
    Task<Book?> GetByIdAsync(int id);
    Task<int> Create(Book book);
    Task Delete(Book book);
    Task Update();
}
