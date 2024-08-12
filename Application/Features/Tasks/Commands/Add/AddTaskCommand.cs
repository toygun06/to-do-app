using Application.Repositories;
using AutoMapper;
using TaskStatus = Domain.Enums.TaskStatus;
using MediatR;
using Task = Domain.Entities.Task;

namespace Application.Features.Tasks.Commands.Add
{
    public class AddTaskCommand : IRequest<AddTaskResponse>
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, AddTaskResponse>
        {
            private readonly IMapper _mapper;
            private readonly ITaskRepository _taskRepository;

            public AddTaskCommandHandler(IMapper mapper, ITaskRepository taskRepository)
            {
                _mapper = mapper;
                _taskRepository = taskRepository;
            }

            public async Task<AddTaskResponse> Handle(AddTaskCommand request, CancellationToken cancellationToken)
            {
                var task = _mapper.Map<Task>(request);
                //task.UserId = request.UserId;
                //task.Title = request.Title;
                //task.Description = request.Description;
                task.Status = TaskStatus.New;

                await _taskRepository.AddAsync(task);
                var response = _mapper.Map<AddTaskResponse>(task);
                return response;
            }
        }

    }
}
