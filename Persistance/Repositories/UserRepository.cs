using Application.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entitites;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class UserRepository : EfRepositoryBase<User, int, ToDoContext>, IUserRepository
    {
        public UserRepository(ToDoContext context) : base(context) 
        {
        }

        public async Task<IList<OperationClaim>> GetClaimsAsync(User user)
        {
            var result = from oc in Context.Set<OperationClaim>()
                         join uoc in Context.Set<UserOperationClaim>()
                             on oc.Id equals uoc.OperationClaimId
                         where uoc.UserId == user.Id
                         select new Core.Security.Entitites.OperationClaim { Id = oc.Id, Name = oc.Name };
            return await result.ToListAsync();
        }
    }
}
