using AutoMapper;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.DTOs;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Commands.UpdateUserProfileSocialPlatform
{
    public class UpdateUserProfileSocialPlatformCommand : IRequest<UpdatedUserProfileSocialPlatformDTO>
    {
        public int Id { get; set; }
        public int SocialPlaformId { get; set; }
        public int UserProfileId { get; set; }
        public string SocialPlatformURI { get; set; }

        public class UpdateUserProfileSocialPlatformCommandHandler : IRequestHandler<UpdateUserProfileSocialPlatformCommand, UpdatedUserProfileSocialPlatformDTO>
        {
            private readonly IUserProfileSocialPlatformRepository _userProfileSocialPlatformRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileSocialPlatformBusinessRules _userProfileSocialPlatformBusinessRules;

            public UpdateUserProfileSocialPlatformCommandHandler(IUserProfileSocialPlatformRepository userProfileSocialPlatformRepository, IMapper mapper, UserProfileSocialPlatformBusinessRules userProfileSocialPlatformBusinessRules)
            {
                _userProfileSocialPlatformRepository = userProfileSocialPlatformRepository;
                _mapper = mapper;
                _userProfileSocialPlatformBusinessRules = userProfileSocialPlatformBusinessRules;
            }

            public async Task<UpdatedUserProfileSocialPlatformDTO> Handle(UpdateUserProfileSocialPlatformCommand request, CancellationToken cancellationToken)
            {
                await _userProfileSocialPlatformBusinessRules.UserProfileSocialPlatformMustExistWhenRequested(request.Id);
                await _userProfileSocialPlatformBusinessRules.UserProfileSocialPlatformNameMustBeUniqueWhenUpdating(request.Id, request.UserProfileId, request.SocialPlaformId, request.SocialPlatformURI);

                UserProfileSocialPlatform mappedUserProfileSocialPlatform = _mapper.Map<UserProfileSocialPlatform>(request);
                UserProfileSocialPlatform updatedUserProfileSocialPlatform = await _userProfileSocialPlatformRepository.UpdateAsync(mappedUserProfileSocialPlatform);

                UserProfileSocialPlatform? userProfileSocialPlatform = await _userProfileSocialPlatformRepository.GetAsync(u => u.Id == request.Id, include: u => u.Include(p => p.SocialPlatform).Include(p => p.UserProfile));
                UpdatedUserProfileSocialPlatformDTO updatedUserProfileSocialPlatformDTO = _mapper.Map<UpdatedUserProfileSocialPlatformDTO>(userProfileSocialPlatform);
                return updatedUserProfileSocialPlatformDTO;
            }
        }
    }
}
