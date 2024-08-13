using Application.Features.Tasks.Commands.Add;
using Application.Features.Tasks.Commands.Update;
using Application.Features.Tasks.Commands.UpdateTaskStatus;
using AutoMapper;
using Task = Domain.Entities.Task;

namespace Application.Features.Tasks.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, AddTaskCommand>().ReverseMap();
            CreateMap<Task, AddTaskResponse>().ReverseMap();

            CreateMap<Task, UpdateTaskCommand>().ReverseMap();
            CreateMap<Task, UpdateTaskResponse>().ReverseMap();

            CreateMap<Task, UpdateTaskStatusCommand>().ReverseMap();
            CreateMap<Task, UpdateTaskStatusResponse>().ReverseMap();

        }
    }
}
