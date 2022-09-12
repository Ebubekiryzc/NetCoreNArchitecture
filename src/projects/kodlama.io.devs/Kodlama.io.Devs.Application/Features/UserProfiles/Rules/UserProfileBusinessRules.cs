using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfiles.Constants;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Rules
{
    public class UserProfileBusinessRules
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileBusinessRules(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task UserProfileEmailMustBeUniqueWhenInserting(string email)
        {
            IPaginate<UserProfile> result = await _userProfileRepository.GetListAsync(u => u.Email == email);
            if (result.Items.Any()) throw new BusinessException(ExceptionMessages.UserProfileEmailExist);
        }

        public async Task UserProfileEmailMustBeUniqueWhenUpdating(int id, string email)
        {
            UserProfile? result = await _userProfileRepository.GetAsync(u => u.Id != id && u.Email == email);
            if (result == null) throw new BusinessException(ExceptionMessages.UserProfileEmailExist);
        }

        public async Task UserProfileMustExistWhenRequested(int id)
        {
            UserProfile? result = await _userProfileRepository.GetAsync(p => p.Id == id, enableTracking: false);
            if (result == null) throw new BusinessException(ExceptionMessages.UserProfileIsNull);
        }

        public void UserProfileMustExistWhenRequested(UserProfile? userProfile)
        {
            if (userProfile == null) throw new BusinessException(ExceptionMessages.UserProfileIsNull);
        }
    }
}
