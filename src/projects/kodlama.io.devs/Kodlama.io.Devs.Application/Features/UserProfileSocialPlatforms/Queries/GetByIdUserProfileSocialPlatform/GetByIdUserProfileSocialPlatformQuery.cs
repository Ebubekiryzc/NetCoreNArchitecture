using AutoMapper;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.DTOs;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Queries.GetByIdUserProfileSocialPlatform
{
    public class GetByIdUserProfileSocialPlatformQuery : IRequest<UserProfileSocialPlatformGetByIdDTO>
    {
        public int Id { get; set; }
        public class GetByIdUserProfileSocialPlatformQueryHandler : IRequestHandler<GetByIdUserProfileSocialPlatformQuery, UserProfileSocialPlatformGetByIdDTO>
        {
            private readonly IUserProfileSocialPlatformRepository _userProfileSocialPlatformRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileSocialPlatformBusinessRules _userProfileSocialPlatformBusinessRules;

            public GetByIdUserProfileSocialPlatformQueryHandler(IUserProfileSocialPlatformRepository userProfileSocialPlatformRepository, IMapper mapper, UserProfileSocialPlatformBusinessRules userProfileSocialPlatformBusinessRules)
            {
                _userProfileSocialPlatformRepository = userProfileSocialPlatformRepository;
                _mapper = mapper;
                _userProfileSocialPlatformBusinessRules = userProfileSocialPlatformBusinessRules;
            }

            public async Task<UserProfileSocialPlatformGetByIdDTO> Handle(GetByIdUserProfileSocialPlatformQuery request, CancellationToken cancellationToken)
            {
                UserProfileSocialPlatform? userProfileSocialPlatform = await _userProfileSocialPlatformRepository.GetAsync(u => u.Id == request.Id, include: u => u.Include(p => p.SocialPlatform).Include(p => p.UserProfile));
                _userProfileSocialPlatformBusinessRules.UserProfileSocialPlatformMustExistWhenRequested(userProfileSocialPlatform);

                UserProfileSocialPlatformGetByIdDTO userProfileSocialPlatformGetByIdDTO = _mapper.Map<UserProfileSocialPlatformGetByIdDTO>(userProfileSocialPlatform);
                return userProfileSocialPlatformGetByIdDTO;
            }
        }
    }
}
