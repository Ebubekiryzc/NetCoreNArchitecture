using AutoMapper;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.DTOs;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Commands.CreateUserProfileSocialPlatform
{
    public class CreateUserProfileSocialPlatformCommand : IRequest<CreatedUserProfileSocialPlatformDTO>
    {
        public int UserId { get; set; }
        public int SocialPlatformId { get; set; }
        public string SocialProfileURI { get; set; }

        public class CreateUserProfileSocialPlatformCommandHandler : IRequestHandler<CreateUserProfileSocialPlatformCommand, CreatedUserProfileSocialPlatformDTO>
        {
            private readonly IUserProfileSocialPlatformRepository _userProfileSocialPlatformRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileSocialPlatformBusinessRules _userProfileSocialPlatformBusinessRules;

            public CreateUserProfileSocialPlatformCommandHandler(IUserProfileSocialPlatformRepository userProfileSocialPlatformRepository, IMapper mapper, UserProfileSocialPlatformBusinessRules userProfileSocialPlatformBusinessRules)
            {
                _userProfileSocialPlatformRepository = userProfileSocialPlatformRepository;
                _mapper = mapper;
                _userProfileSocialPlatformBusinessRules = userProfileSocialPlatformBusinessRules;
            }

            public async Task<CreatedUserProfileSocialPlatformDTO> Handle(CreateUserProfileSocialPlatformCommand request, CancellationToken cancellationToken)
            {
                await _userProfileSocialPlatformBusinessRules.UserProfileSocialPlatformMustBeUniqueWhenInserting(request.UserId, request.SocialPlatformId, request.SocialProfileURI);

                UserProfileSocialPlatform mappedUserProfileSocialPlatform = _mapper.Map<UserProfileSocialPlatform>(request);
                UserProfileSocialPlatform createdUserProfileSocialPlatform = await _userProfileSocialPlatformRepository.AddAsync(mappedUserProfileSocialPlatform);

                UserProfileSocialPlatform? userProfileSocialPlatform = await _userProfileSocialPlatformRepository.GetAsync(u => u.Id == createdUserProfileSocialPlatform.Id, include: u => u.Include(p => p.SocialPlatform).Include(p => p.UserProfile));
                CreatedUserProfileSocialPlatformDTO createdUserProfileSocialPlatformDTO = _mapper.Map<CreatedUserProfileSocialPlatformDTO>(userProfileSocialPlatform);
                return createdUserProfileSocialPlatformDTO;
            }
        }
    }
}
