using Application.Features.Tasks.Commands.Add;
using Application.Features.Tasks.Commands.Update;
using Application.Features.Tasks.Commands.UpdateTaskStatus;
using Application.Features.Tasks.Queries.GetById;
using Application.Features.Tasks.Queries.GetByUserId;
using Application.Features.Tasks.Queries.GetPaginatedByUserId;
using AutoMapper;
using Domain.Dtos;
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

            CreateMap<Task, GetTaskByIdQuery>().ReverseMap(); //Gerekmeyebilir
            CreateMap<Task, GetTaskByIdResponse>().ReverseMap();

            CreateMap<Task, TaskDto>();
            CreateMap<Task, GetTasksByUserIdQuery>().ReverseMap(); //Gerekmeyebilir
            CreateMap<List<Task>, GetTasksByUserIdResponse>()
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src));

            CreateMap<Task, GetPaginatedTasksByUserIdResponse>();
        }
    }
}
