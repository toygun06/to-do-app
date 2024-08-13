using Application.Features.Tasks.Rules;
using Application.Repositories;
using Task = Domain.Entities.Task;
using MediatR;
using Application.Features.Tasks.Constants;

namespace Application.Features.Tasks.Commands.Delete
{
    public class DeleteTaskCommand : IRequest<DeleteTaskResponse>
    {
        public int Id { get; set; }
    }

    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, DeleteTaskResponse>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly TaskBusinessRules _taskBusinessRules;

        public DeleteTaskCommandHandler(ITaskRepository taskRepository, TaskBusinessRules taskBusinessRules)
        {
            _taskRepository = taskRepository;
            _taskBusinessRules = taskBusinessRules;
        }

        public async Task<DeleteTaskResponse> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            Task tasktoDelete = await _taskBusinessRules.TaskCheck(request.Id);
            await _taskRepository.DeleteAsync(tasktoDelete);

            return new()
            {
                Message = TaskMessages.DeleteWasSuccess
            };
        }
    }
}
