using Core.Domain;
using TaskStatus = Domain.Enums.TaskStatus;

namespace Domain.Entities
{
    public class Task : Entity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
