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

namespace Application.Features.Tasks.Commands.Update
{
    public class UpdateTaskCommand : IRequest<UpdateTaskResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, UpdateTaskResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;
        private readonly TaskBusinessRules _taskBusinessRules;

        public UpdateTaskCommandHandler(IMapper mapper, ITaskRepository taskRepository, TaskBusinessRules taskBusinessRules)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
            _taskBusinessRules = taskBusinessRules;
        }

        public async Task<UpdateTaskResponse> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            Task existingTask = await _taskBusinessRules.TaskCheck(request.Id);
            
            var updatedTask = _mapper.Map(request, existingTask);

            updatedTask.UpdatedDate = DateTime.Now;

            await _taskRepository.UpdateAsync(updatedTask);
            UpdateTaskResponse response = _mapper.Map<UpdateTaskResponse>(updatedTask);

            return response;
        }
    }
}
