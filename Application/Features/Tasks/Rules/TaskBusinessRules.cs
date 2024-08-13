using Application.Features.Tasks.Constants;
using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions.Types;
using Task = Domain.Entities.Task;

namespace Application.Features.Tasks.Rules
{
    public class TaskBusinessRules : BaseBusinessRules
    {
        private readonly ITaskRepository _taskRepository;

        public TaskBusinessRules(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Task> TaskCheck(int Id)
        {
            var task = await _taskRepository.GetAsync(x => x.Id == Id);
            if (task is null) throw new BusinessException(TaskMessages.TaskNotFound);
            return task;
        }
    }
}
