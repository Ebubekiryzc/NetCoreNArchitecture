using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Constants;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Rules
{
    public class UserProfileSocialPlatformBusinessRules
    {
        private readonly IUserProfileSocialPlatformRepository _userProfileSocialPlatformRepository;

        public UserProfileSocialPlatformBusinessRules(IUserProfileSocialPlatformRepository userProfileSocialPlatformRepository)
        {
            _userProfileSocialPlatformRepository = userProfileSocialPlatformRepository;
        }

        public async Task UserProfileSocialPlatformMustBeUniqueWhenInserting(int userId, int socialPlatformId, string profileURI)
        {
            IPaginate<UserProfileSocialPlatform> result = await _userProfileSocialPlatformRepository.GetListAsync(up => up.SocialPlatformId == socialPlatformId && up.UserProfileId == userId && up.SocialProfileURI == profileURI);
            if (result.Items.Any()) throw new BusinessException(ExceptionMessages.UserProfileSocialPlatformExist);
        }

        public async Task UserProfileSocialPlatformNameMustBeUniqueWhenUpdating(int id, int userId, int socialPlatformId, string profileURI)
        {
            IPaginate<UserProfileSocialPlatform> result = await _userProfileSocialPlatformRepository.GetListAsync(up => up.Id != id && up.SocialPlatformId == socialPlatformId && up.UserProfileId == userId && up.SocialProfileURI == profileURI);
            if (result.Items.Any()) throw new BusinessException(ExceptionMessages.UserProfileSocialPlatformExist);
        }

        public async Task UserProfileSocialPlatformMustExistWhenRequested(int id)
        {
            UserProfileSocialPlatform? result = await _userProfileSocialPlatformRepository.GetAsync(p => p.Id == id, enableTracking: false);
            if (result == null) throw new BusinessException(ExceptionMessages.UserProfileSocialPlatformIsNull);
        }

        public void UserProfileSocialPlatformMustExistWhenRequested(UserProfileSocialPlatform? userProfileSocialPlatform)
        {
            if (userProfileSocialPlatform == null) throw new BusinessException(ExceptionMessages.UserProfileSocialPlatformIsNull);
        }
    }
}
