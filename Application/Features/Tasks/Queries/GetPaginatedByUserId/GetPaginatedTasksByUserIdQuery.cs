using Application.Features.Tasks.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Tasks.Queries.GetPaginatedByUserId
{
    public class GetPaginatedTasksByUserIdQuery : IRequest<IPaginate<GetPaginatedTasksByUserIdResponse>>
    {
        public int UserId { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public class GetPaginatedTasksByUserIdQueryHandler : IRequestHandler<GetPaginatedTasksByUserIdQuery, IPaginate<GetPaginatedTasksByUserIdResponse>>
        {
            private readonly IMapper _mapper;
            private readonly ITaskRepository _taskRepository;
            private readonly TaskBusinessRules _taskBusinessRules;

            public GetPaginatedTasksByUserIdQueryHandler(IMapper mapper, ITaskRepository tasRepository, TaskBusinessRules taskBusinessRules)
            {
                _mapper = mapper;
                _taskRepository = tasRepository;
                _taskBusinessRules = taskBusinessRules;
            }

            public async Task<IPaginate<GetPaginatedTasksByUserIdResponse>> Handle(GetPaginatedTasksByUserIdQuery request, CancellationToken cancellationToken)
            {
                var tasks = await _taskRepository.GetListAsync(
                    index: request.PageIndex,
                    size: request.PageSize,
                    enableTracking: false,
                    cancellationToken: cancellationToken
                    );

                var result = _mapper.Map<List<GetPaginatedTasksByUserIdResponse>>(tasks.Items);
                return new Paginate<GetPaginatedTasksByUserIdResponse>(result.AsQueryable(), tasks.Pagination);
            }
        }

    }
}
