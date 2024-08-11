using Application.Features.Users.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.GetById
{
    public class GetUserByIdQuery :IRequest<GetUserByIdResponse>
    {
        public int Id { get; set; }

        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly UserBusinessRules _userBusinessRules;

            public GetUserByIdQueryHandler(IMapper mapper, IUserRepository userRepository, UserBusinessRules userBusinessRules)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(
                    predicate: x => x.Id == request.Id,
                    enableTracking: false
                    );

                _userBusinessRules.IsSelectedEntityAvaiable(user);

                var response = _mapper.Map<GetUserByIdResponse>(user);
                return response;
            }
        }
    }
}
