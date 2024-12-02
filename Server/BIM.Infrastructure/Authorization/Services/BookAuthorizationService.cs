using BIM.Domain.Contants;
using BIM.Domain.Entities;
using BIM.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BIM.Infrastructure.Authorization.Services;

public class BookAuthorizationService : IBookAuthorizationService
{
    public bool Authorize(Book book, ResourceOperation resourceOperation)
    {


        if (resourceOperation == ResourceOperation.Read || resourceOperation == ResourceOperation.Create)
        {
            return true;
        }

        if (resourceOperation == ResourceOperation.Delete)
        {
            return true;
        }

        if ((resourceOperation == ResourceOperation.Delete || resourceOperation == ResourceOperation.Update))
        {
            return true;
        }

        return false;
    }
}
