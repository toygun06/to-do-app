using Application.Features.Users.Rules;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest<UpdateUserResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var existingUser = await _userRepository.GetAsync(
                    predicate: x => x.Id == request.Id,
                    enableTracking: true
                    );
                //Duplicate mail check
                await _userBusinessRules.UpdateDuplicateNameCheckAsync(request.Email, request.Id);

                //Mapper kullanarak gerekli alanların kopyalanması
                var updatedUser = _mapper.Map(request, existingUser);

                updatedUser.UpdatedDate = DateTime.Now;

                //passwordHash ve passwordSalt alanlarının üzerine yazılmasını engelleme
                updatedUser.PasswordHash = existingUser.PasswordHash;
                updatedUser.PasswordSalt = existingUser.PasswordSalt;

                //Güncellenmiş hastanın veritabanına kaydı
                await _userRepository.UpdateAsync(updatedUser);
                UpdateUserResponse response = _mapper.Map<UpdateUserResponse>(updatedUser);

                return response;
            }
        }
    }
}
