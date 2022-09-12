using AutoMapper;
using Kodlama.io.Devs.Application.Features.UserProfiles.DTOs;
using Kodlama.io.Devs.Application.Features.UserProfiles.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Commands.DeleteUserProfile
{
    public class DeleteUserProfileCommand : IRequest<DeletedUserProfileDTO>
    {
        public int Id { get; set; }

        public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, DeletedUserProfileDTO>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileBusinessRules _userProfileBusinessRules;

            public DeleteUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IMapper mapper, UserProfileBusinessRules userProfileBusinessRules)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
                _userProfileBusinessRules = userProfileBusinessRules;
            }

            public async Task<DeletedUserProfileDTO> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
            {
                UserProfile? userProfileToDelete = await _userProfileRepository.GetAsync(u => u.Id == request.Id, include: u=> u.Include(p => p.Gender));
                _userProfileBusinessRules.UserProfileMustExistWhenRequested(userProfileToDelete);

                UserProfile? deletedUserProfile = await _userProfileRepository.DeleteAsync(userProfileToDelete);
                DeletedUserProfileDTO deletedUserProfileDTO = _mapper.Map<DeletedUserProfileDTO>(userProfileToDelete);
                return deletedUserProfileDTO;
            }
        }
    }
}
