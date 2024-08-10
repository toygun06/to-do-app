
using Application.Features.Auth.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Transaction;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Command.Register
{
    public class UserRegisterCommand : IRequest<UserRegisterResponse>, ITransactionalRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }

        public class UserRegisterHandler : IRequestHandler<UserRegisterCommand, UserRegisterResponse>
        {
            private readonly ITokenHelper _tokenHelper;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;

            public UserRegisterHandler(ITokenHelper tokenHelper, AuthBusinessRules authBusinessRules, IMapper mapper, IUserRepository userRepository)
            {
                _tokenHelper = tokenHelper;
                _authBusinessRules = authBusinessRules;
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<UserRegisterResponse> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
            {
                //rules
                await _authBusinessRules.DuplicateEmailChechAsync(request.Email);

                //password hashing
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(
                    password:request.Password,
                    passwordHash: out passwordHash,
                    passwordSalt: out passwordSalt);
                User? user = _mapper.Map<User>(request);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                await _userRepository.AddAsync(user);

                return _mapper.Map<UserRegisterResponse>(user);
            }
        }
    }
}
