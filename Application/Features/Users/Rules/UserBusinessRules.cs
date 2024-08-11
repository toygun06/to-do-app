using Application.Features.Auth.Constant;
using Application.Features.Users.Constants;
using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions.Types;
using Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules : BaseBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void IsSelectedEntityAvaiable(User? user)
        {
            if (user == null) throw new BusinessException(UserMessage.UserNotAvailable);
        }


        //public async Task DuplicateEmailChechAsync(string email)
        //{
        //    bool check = await _userRepository.AnyAsync(
        //        predicate: x => x.Email.ToLower() == email.ToLower(),
        //        enableTracking: false);
        //    if (check) throw new BusinessException(AuthMessages.DuplicateEmail);
        //}

        public async Task DuplicateEMailCheckAsync(string email)
        {
            var check = await _userRepository.GetAsync(
                predicate: x => x.Email.ToLower() == email.ToLower());
            if (check != null)
            {
                throw new BusinessException(UserMessage.DuplicateEmail);
            }
        }

        public async Task UpdateDuplicateNameCheckAsync(string email, int id)
        {
            var check = await _userRepository.GetAsync(
                predicate: x => x.Email.ToLower() == email.ToLower());
            if (check != null && check.Id != id) throw new BusinessException(UserMessage.DuplicateEmail);
        }
    }
}
