using Application.Features.Tasks.Queries.GetPaginatedByUserId;
using Application.Features.Tasks.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Enums;
using LinqKit;
using MediatR;
using Task = Domain.Entities.Task;
using TaskStatus = Domain.Enums.TaskStatus;

namespace Application.Features.Tasks.Queries.GetPaginatedFilteredByUserId
{
    public class GetPaginatedFilteredTasksByUserIdQuery : IRequest<IPaginate<GetPaginatedFilteredTasksByUserIdResponse>>
    {
        public int UserId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public TaskStatus? TStatus { get; set; }
        public bool isAscending { get; set; }

        public class GetPaginatedTasksByUserIdQueryHandler : IRequestHandler<GetPaginatedFilteredTasksByUserIdQuery, IPaginate<GetPaginatedFilteredTasksByUserIdResponse>>
        {
            private readonly IMapper _mapper;
            private readonly ITaskRepository _taskRepository;
            private readonly TaskBusinessRules _taskBusinessRules;

            public GetPaginatedTasksByUserIdQueryHandler(IMapper mapper, ITaskRepository taskRepository, TaskBusinessRules taskBusinessRules)
            {
                _mapper = mapper;
                _taskRepository = taskRepository;
                _taskBusinessRules = taskBusinessRules;
            }

            public async Task<IPaginate<GetPaginatedFilteredTasksByUserIdResponse>> Handle(GetPaginatedFilteredTasksByUserIdQuery query, CancellationToken cancellationToken)
            {
                if (query.PageIndex < 1) query.PageIndex = 1;
                if (query.PageSize < 1) query.PageSize = 10;

                List<Task> ruled = await _taskBusinessRules.PaginatedTaskCheckByUserId(query.UserId);

                var predicate = PredicateBuilder.New<Task>(x => ruled.Select(r => r.Id).Contains(x.Id));

                if (query.TStatus.HasValue)
                {
                    predicate = predicate.And(x => x.Status.Equals(query.TStatus.Value));
                }

                var tasks = await _taskRepository.GetListAsync(
                    predicate: predicate,
                    index: query.PageIndex,
                    size: query.PageSize,
                    enableTracking: false,
                    cancellationToken: cancellationToken,
                    orderBy: query.isAscending ? x => x.OrderBy(t => t.UpdatedDate ?? t.CreatedDate) : x => x.OrderByDescending(t => t.UpdatedDate ?? t.CreatedDate)
                    );


                var result = _mapper.Map<List<GetPaginatedFilteredTasksByUserIdResponse>>(tasks.Items);
                return new Paginate<GetPaginatedFilteredTasksByUserIdResponse>(result.AsQueryable(), tasks.Pagination);
            }
        }

    }
}