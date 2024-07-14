using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class UserRepository : EfRepositoryBase<User, int, ToDoContext>, IUserRepository
    {
        public UserRepository(ToDoContext context) : base(context) 
        {
        }
    }
}
