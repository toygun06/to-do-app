using Domain.Dtos;
using TaskStatus = Domain.Enums.TaskStatus;

namespace Application.Features.Tasks.Queries.GetByUserId
{
    public class GetTasksByUserIdResponse
    {
        public List<TaskDto> Tasks { get; set; }

        public GetTasksByUserIdResponse()
        {
            Tasks = new List<TaskDto>();
        }
    }
}
