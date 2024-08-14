using Application.Features.Tasks.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Dtos;
using MediatR;
using Task = Domain.Entities.Task;


namespace Application.Features.Tasks.Queries.GetByUserId
{
    public class GetTasksByUserIdQuery : IRequest<GetTasksByUserIdResponse>
    {
        public int UserId { get; set; }

        public class GetTasksByUserIdQueryHandler : IRequestHandler<GetTasksByUserIdQuery, GetTasksByUserIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly ITaskRepository _taskRepository;
            private readonly TaskBusinessRules _taskBusinessRules;

            public GetTasksByUserIdQueryHandler(IMapper mapper, ITaskRepository taskRepository, TaskBusinessRules taskBusinessRules)
            {
                _mapper = mapper;
                _taskRepository = taskRepository;
                _taskBusinessRules = taskBusinessRules;
            }

            public async Task<GetTasksByUserIdResponse> Handle(GetTasksByUserIdQuery query, CancellationToken cancellationToken)
            {
                List<Task> result = await _taskBusinessRules.TaskCheckByUserId(query.UserId);


                var response = new GetTasksByUserIdResponse
                {
                    Tasks = _mapper.Map<List<TaskDto>>(result)
                };

                return response;

            }
        }

    }
}
