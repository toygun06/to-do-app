﻿using TaskStatus = Domain.Enums.TaskStatus;

namespace Application.Features.Tasks.Queries.GetById
{
    public class GetTaskByIdResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public int UserId { get; set; }
    }
}
