using TaskStatus = Domain.Enums.TaskStatus;

namespace Application.Features.Tasks.Commands.Add
{
    public class AddTaskResponse
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
    }
}
