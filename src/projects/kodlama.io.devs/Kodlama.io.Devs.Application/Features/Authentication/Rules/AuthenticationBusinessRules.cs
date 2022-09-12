using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Features.Authentication.Constants;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Authentication.Rules
{
    public class AuthenticationBusinessRules
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public AuthenticationBusinessRules(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task AuthenticationEmailMustBeUniqueWhenRegister(string email)
        {
            IPaginate<UserProfile> result = await _userProfileRepository.GetListAsync(u => u.Email == email);
            if (result.Items.Any()) throw new BusinessException(ExceptionMessages.AuthenticationUserEmailExist);
        }

        public void AuthenticationCredentialsMustMatchWhenLogin(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            bool result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!result) throw new BusinessException(ExceptionMessages.AuthenticationCredentialsNotMatch);
        }

        public void AuthenticationUserProfileMustExistWhenLogin(UserProfile? userProfile)
        {
            if (userProfile == null) throw new BusinessException(ExceptionMessages.AuthenticationUserEmailNotFound);
        }
    }
}
