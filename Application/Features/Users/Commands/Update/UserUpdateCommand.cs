using Application.Features.Users.Rules;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Commands.Update
{
    public class UserUpdateCommand : IRequest<UserUpdateResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, UserUpdateResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public UserUpdateCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UserUpdateResponse> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
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
                UserUpdateResponse response = _mapper.Map<UserUpdateResponse>(updatedUser);

                return response;
            }
        }
    }
}
