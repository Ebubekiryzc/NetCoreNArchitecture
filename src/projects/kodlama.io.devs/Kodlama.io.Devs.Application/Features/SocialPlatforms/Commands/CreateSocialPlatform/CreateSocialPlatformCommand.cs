using AutoMapper;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.DTOs;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.CreateSocialPlatform
{
    public class CreateSocialPlatformCommand : IRequest<CreatedSocialPlatformDTO>
    {
        public string Name { get; set; }
        public string Domain { get; set; }

        public class CreateSocialPlatformCommandHandler : IRequestHandler<CreateSocialPlatformCommand, CreatedSocialPlatformDTO>
        {
            private readonly ISocialPlatformRepository _socialPlatformRepository;
            private readonly IMapper _mapper;
            private readonly SocialPlatformBusinessRules _socialPlatformBusinessRules;

            public CreateSocialPlatformCommandHandler(ISocialPlatformRepository socialPlatformRepository, IMapper mapper, SocialPlatformBusinessRules socialPlatformBusinessRules)
            {
                _socialPlatformRepository = socialPlatformRepository;
                _mapper = mapper;
                _socialPlatformBusinessRules = socialPlatformBusinessRules;
            }

            public async Task<CreatedSocialPlatformDTO> Handle(CreateSocialPlatformCommand request, CancellationToken cancellationToken)
            {
                await _socialPlatformBusinessRules.SocialPlatformNameMustBeUniqueWhenInserting(request.Name);
                await _socialPlatformBusinessRules.SocialPlatformDomainMustBeUniqueWhenInserting(request.Domain);

                SocialPlatform socialPlatform = _mapper.Map<SocialPlatform>(request);
                SocialPlatform createdSocialPlatform = await _socialPlatformRepository.AddAsync(socialPlatform);
                CreatedSocialPlatformDTO createdSocialPlatformDTO = _mapper.Map<CreatedSocialPlatformDTO>(createdSocialPlatform);
                return createdSocialPlatformDTO;
            }
        }
    }
}
