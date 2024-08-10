using Core.Persistence.Repositories;
using Core.Security.Entitites;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IUserRepository : IAsyncRepository<User, int>, IRepository<User, int>
    {
        Task<IList<OperationClaim>> GetClaimsAsync(User user);
    }
}
