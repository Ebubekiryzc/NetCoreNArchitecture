using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Constants;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.SocialPlatforms.Rules
{
    public class SocialPlatformBusinessRules
    {
        private readonly ISocialPlatformRepository _socialPlatformRepository;

        public SocialPlatformBusinessRules(ISocialPlatformRepository socialPlatformRepository)
        {
            _socialPlatformRepository = socialPlatformRepository;
        }

        public async Task SocialPlatformNameMustBeUniqueWhenInserting(string name)
        {
            IPaginate<SocialPlatform> result = await _socialPlatformRepository.GetListAsync(s => s.Name == name);
            if (result.Items.Any()) throw new BusinessException(ExceptionMessages.SocialPlatformNameExist);
        }

        public async Task SocialPlatformDomainMustBeUniqueWhenInserting(string domain)
        {
            IPaginate<SocialPlatform> result = await _socialPlatformRepository.GetListAsync(s => s.Domain == domain);
            if (result.Items.Any()) throw new BusinessException(ExceptionMessages.SocialPlatformDomainExist);
        }

        public async Task SocialPlatformNameMustBeUniqueWhenUpdating(int id, string name, string domain)
        {
            IPaginate<SocialPlatform> nameResult = await _socialPlatformRepository.GetListAsync(p => p.Id != id && p.Name == name);
            if (nameResult.Items.Any()) throw new BusinessException(ExceptionMessages.SocialPlatformNameExist);

            IPaginate<SocialPlatform> domainResult = await _socialPlatformRepository.GetListAsync(p => p.Id != id && p.Domain == domain);
            if (domainResult.Items.Any()) throw new BusinessException(ExceptionMessages.SocialPlatformNameExist);
        }

        public async Task SocialPlatformMustExistWhenRequested(int id)
        {
            SocialPlatform? result = await _socialPlatformRepository.GetAsync(p => p.Id == id, enableTracking: false);
            if (result == null) throw new BusinessException(ExceptionMessages.SocialPlatformIsNull);
        }

        public void SocialPlatformMustExistWhenRequested(SocialPlatform? socialPlatform)
        {
            if (socialPlatform == null) throw new BusinessException(ExceptionMessages.SocialPlatformIsNull);
        }
    }
}
