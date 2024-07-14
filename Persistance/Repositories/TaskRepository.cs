using Application.Repositories;
using Core.Persistence.Repositories;
using Persistance.Contexts;
using Task = Domain.Entities.Task;

namespace Persistance.Repositories
{
    public class TaskRepository : EfRepositoryBase<Task, int, ToDoContext>, ITaskRepository
    {
        public TaskRepository(ToDoContext context) : base(context) 
        {
        }
    }
}
