using BIM.Domain.Entities;

namespace BIM.Domain.Respositories;

public interface IBooksRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);
    Task<int> Create(Book book);
    Task Delete(Book book);
    Task Update();
}
