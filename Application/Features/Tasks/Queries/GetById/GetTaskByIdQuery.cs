using Application.Features.Tasks.Rules;
using Application.Repositories;
using AutoMapper;
using Task = Domain.Entities.Task;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tasks.Queries.GetById
{
    public class GetTaskByIdQuery : IRequest<GetTaskByIdResponse>
    {
        public int Id { get; set; }

        public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, GetTaskByIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly ITaskRepository _taskRepository;
            private readonly TaskBusinessRules _taskBusinessRules;

            public GetTaskByIdQueryHandler(IMapper mapper, ITaskRepository taskRepository, TaskBusinessRules taskBusinessRules)
            {
                _mapper = mapper;
                _taskRepository = taskRepository;
                _taskBusinessRules = taskBusinessRules;
            }

            public async Task<GetTaskByIdResponse> Handle (GetTaskByIdQuery request, CancellationToken cancellationToken)
            {
                Task task = await _taskBusinessRules.TaskCheck(request.Id);

                var response = _mapper.Map<GetTaskByIdResponse>(task);
                return response;

            }
        }
    }
}
