using AutoMapper;
using Kodlama.io.Devs.Application.Features.UserProfiles.DTOs;
using Kodlama.io.Devs.Application.Features.UserProfiles.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommand : IRequest<UpdatedUserProfileDTO>
    {
        public int UserId { get; set; }
        public int GenderId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
        public DateTime DateOfBirth { get; set; }

        public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UpdatedUserProfileDTO>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileBusinessRules _userProfileBusinessRules;

            public UpdateUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IMapper mapper, UserProfileBusinessRules userProfileBusinessRules)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
                _userProfileBusinessRules = userProfileBusinessRules;
            }

            public async Task<UpdatedUserProfileDTO> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
            {
                await _userProfileBusinessRules.UserProfileEmailMustBeUniqueWhenUpdating(request.UserId, request.Email);

                UserProfile mappedUserProfile = _mapper.Map<UserProfile>(request);
                UserProfile updatedUserProfile = await _userProfileRepository.UpdateAsync(mappedUserProfile);

                UserProfile? userProfile = await _userProfileRepository.GetAsync(u => u.Id == updatedUserProfile.Id, include: u => u.Include(p => p.Gender));
                UpdatedUserProfileDTO updatedUserProfileDTO = _mapper.Map<UpdatedUserProfileDTO>(userProfile);
                return updatedUserProfileDTO;
            }
        }
    }
}
