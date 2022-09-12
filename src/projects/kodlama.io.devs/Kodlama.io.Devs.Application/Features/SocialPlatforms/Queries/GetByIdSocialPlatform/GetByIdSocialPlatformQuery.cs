using AutoMapper;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.DTOs;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.SocialPlatforms.Queries.GetByIdSocialPlatform
{
    public class GetByIdSocialPlatformQuery : IRequest<SocialPlatformGetByIdDTO>
    {
        public int Id { get; set; }

        public class GetByIdSocialPlatformQueryHandler : IRequestHandler<GetByIdSocialPlatformQuery, SocialPlatformGetByIdDTO>
        {
            private readonly ISocialPlatformRepository _socialPlatformRepository;
            private readonly IMapper _mapper;
            private readonly SocialPlatformBusinessRules _socialPlatformBusinessRules;

            public GetByIdSocialPlatformQueryHandler(ISocialPlatformRepository socialPlatformRepository, IMapper mapper, SocialPlatformBusinessRules socialPlatformBusinessRules)
            {
                _socialPlatformRepository = socialPlatformRepository;
                _mapper = mapper;
                _socialPlatformBusinessRules = socialPlatformBusinessRules;
            }

            public async Task<SocialPlatformGetByIdDTO> Handle(GetByIdSocialPlatformQuery request, CancellationToken cancellationToken)
            {
                SocialPlatform? socialPlatform = await _socialPlatformRepository.GetAsync(s => s.Id == request.Id);
                _socialPlatformBusinessRules.SocialPlatformMustExistWhenRequested(socialPlatform);

                SocialPlatformGetByIdDTO socialPlatformGetByIdDTO = _mapper.Map<SocialPlatformGetByIdDTO>(socialPlatform);
                return socialPlatformGetByIdDTO;
            }
        }
    }
}
