﻿using Core.Domain;
using TaskStatus = Domain.Enums.TaskStatus;

namespace Application.Features.Tasks.Queries.GetPaginatedByUserId
{
    public class GetPaginatedFilteredTasksByUserIdResponse : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
