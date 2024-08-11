using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.SoftDelete
{
    public class UserSoftDeleteCommand : IRequest<UserSoftDeleteResponse>
    {
        public int Id { get; set; }

        public class UserSoftDeleteCommandHandler : IRequestHandler<UserSoftDeleteCommand, UserSoftDeleteResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public UserSoftDeleteCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<UserSoftDeleteResponse> Handle(UserSoftDeleteCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(predicate: x => x.Id == request.Id);

                user.Status = false;

                await _userRepository.UpdateAsync(user);
                UserSoftDeleteResponse response = _mapper.Map<UserSoftDeleteResponse>(user);

                return response ;
            }
        }
    }
}
