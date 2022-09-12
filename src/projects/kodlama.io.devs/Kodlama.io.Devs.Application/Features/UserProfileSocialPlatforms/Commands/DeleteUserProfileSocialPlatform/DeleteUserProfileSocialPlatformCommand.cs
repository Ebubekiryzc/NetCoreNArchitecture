using AutoMapper;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.DTOs;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Commands.DeleteUserProfileSocialPlatform
{
    public class DeleteUserProfileSocialPlatformCommand: IRequest<DeletedUserProfileSocialPlatformDTO>
    {
        public int Id { get; set; }
        public class DeleteUserProfileSocialPlatformCommandHandler : IRequestHandler<DeleteUserProfileSocialPlatformCommand, DeletedUserProfileSocialPlatformDTO>
        {
            private readonly IUserProfileSocialPlatformRepository _userProfileSocialPlatformRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileSocialPlatformBusinessRules _userProfileSocialPlatformBusinessRules;

            public DeleteUserProfileSocialPlatformCommandHandler(IUserProfileSocialPlatformRepository userProfileSocialPlatformRepository, IMapper mapper, UserProfileSocialPlatformBusinessRules userProfileSocialPlatformBusinessRules)
            {
                _userProfileSocialPlatformRepository = userProfileSocialPlatformRepository;
                _mapper = mapper;
                _userProfileSocialPlatformBusinessRules = userProfileSocialPlatformBusinessRules;
            }

            public async Task<DeletedUserProfileSocialPlatformDTO> Handle(DeleteUserProfileSocialPlatformCommand request, CancellationToken cancellationToken)
            {
                UserProfileSocialPlatform? userProfileSocialPlatform = await _userProfileSocialPlatformRepository.GetAsync(u=> u.Id == request.Id, include: u=> u.Include(p => p.SocialPlatform).Include(p=> p.UserProfile));
                _userProfileSocialPlatformBusinessRules.UserProfileSocialPlatformMustExistWhenRequested(userProfileSocialPlatform);

                UserProfileSocialPlatform deletedUserProfileSocialPlatform = await _userProfileSocialPlatformRepository.DeleteAsync(userProfileSocialPlatform);
                DeletedUserProfileSocialPlatformDTO deletedUserProfileSocialPlatformDTO = _mapper.Map<DeletedUserProfileSocialPlatformDTO>(userProfileSocialPlatform);
                return deletedUserProfileSocialPlatformDTO;
            }
        }
    }
}
