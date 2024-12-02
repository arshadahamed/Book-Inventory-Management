using BIM.Domain.Contants;
using BIM.Domain.Entities;

namespace BIM.Domain.Interfaces
{
    public interface IBookAuthorizationService
    {
        bool Authorize(Book book, ResourceOperation resourceOperation);
    }
}
