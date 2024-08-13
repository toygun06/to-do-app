using TaskStatus = Domain.Enums.TaskStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tasks.Commands.UpdateTaskStatus
{
    public class UpdateTaskStatusResponse
    {
        public int Id { get; set; }
        public TaskStatus Status { get; set; }
    }
}
