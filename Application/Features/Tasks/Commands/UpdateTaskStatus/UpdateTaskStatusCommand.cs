using Application.Features.Tasks.Rules;
using Application.Repositories;
using AutoMapper;
using Task = Domain.Entities.Task;
using MediatR;
using TaskStatus = Domain.Enums.TaskStatus;


namespace Application.Features.Tasks.Commands.UpdateTaskStatus
{
    public class UpdateTaskStatusCommand : IRequest<UpdateTaskStatusResponse>
    {
        public int Id { get; set; }
        public TaskStatus Status { get; set; }

        public class UpdateTaskStatusCommandHandler : IRequestHandler<UpdateTaskStatusCommand, UpdateTaskStatusResponse>
        {
            private readonly IMapper _mapper;
            private readonly ITaskRepository _taskRepository;
            private readonly TaskBusinessRules _taskBusinessRules;

            public UpdateTaskStatusCommandHandler(IMapper mapper, ITaskRepository taskRepository, TaskBusinessRules taskBusinessRules)
            {
                _mapper = mapper;
                _taskRepository = taskRepository;
                _taskBusinessRules = taskBusinessRules;
            }

            public async Task<UpdateTaskStatusResponse> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
            {
                Task existingTaskStatus = await _taskBusinessRules.TaskCheck(request.Id);

                var updatedTaskStatus = _mapper.Map(request, existingTaskStatus);

                updatedTaskStatus.UpdatedDate = DateTime.Now;

                await _taskRepository.UpdateAsync(updatedTaskStatus);
                UpdateTaskStatusResponse response = _mapper.Map<UpdateTaskStatusResponse>(updatedTaskStatus);

                return response;
            }
        }
    }
}
