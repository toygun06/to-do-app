using Core.Persistence.Repositories;
using Task = Domain.Entities.Task;

namespace Application.Repositories
{
    public interface ITaskRepository : IAsyncRepository<Task, int>, IRepository<Task, int>
    {

    }
}
