using TaskStatus = Domain.Enums.TaskStatus;

namespace Domain.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public int UserId { get; set; }
    }
}
