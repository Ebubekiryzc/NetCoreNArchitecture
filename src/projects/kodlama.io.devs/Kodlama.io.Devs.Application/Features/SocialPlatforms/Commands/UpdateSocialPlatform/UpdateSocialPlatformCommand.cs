using AutoMapper;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.DTOs;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.UpdateSocialPlatform
{
    public class UpdateSocialPlatformCommand : IRequest<UpdatedSocialPlatformDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }

        public class UpdateSocialPlatformCommandHandler : IRequestHandler<UpdateSocialPlatformCommand, UpdatedSocialPlatformDTO>
        {
            private readonly ISocialPlatformRepository _socialPlatformRepository;
            private readonly IMapper _mapper;
            private readonly SocialPlatformBusinessRules _socialPlatformBusinessRules;

            public UpdateSocialPlatformCommandHandler(ISocialPlatformRepository socialPlatformRepository, IMapper mapper, SocialPlatformBusinessRules socialPlatformBusinessRules)
            {
                _socialPlatformRepository = socialPlatformRepository;
                _mapper = mapper;
                _socialPlatformBusinessRules = socialPlatformBusinessRules;
            }

            public async Task<UpdatedSocialPlatformDTO> Handle(UpdateSocialPlatformCommand request, CancellationToken cancellationToken)
            {
                await _socialPlatformBusinessRules.SocialPlatformNameMustBeUniqueWhenUpdating(request.Id, request.Name, request.Domain);

                SocialPlatform mappedSocialPlatform = _mapper.Map<SocialPlatform>(request);
                SocialPlatform updatedSocialPlatform = await _socialPlatformRepository.UpdateAsync(mappedSocialPlatform);
                UpdatedSocialPlatformDTO updatedSocialPlatformDTO = _mapper.Map<UpdatedSocialPlatformDTO>(updatedSocialPlatform);
                return updatedSocialPlatformDTO;
            }
        }
    }
}
