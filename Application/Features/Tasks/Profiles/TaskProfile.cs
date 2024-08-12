using Application.Features.Tasks.Commands.Add;
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

        }
    }
}
