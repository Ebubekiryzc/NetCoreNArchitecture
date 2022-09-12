using AutoMapper;
using Kodlama.io.Devs.Application.Features.UserProfiles.DTOs;
using Kodlama.io.Devs.Application.Features.UserProfiles.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Commands.CreateUserProfile
{
    public class CreateUserProfileCommand : IRequest<CreatedUserProfileDTO>
    {
        public int UserId { get; set; }
        public int GenderId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
        public DateTime DateOfBirth { get; set; }

        public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, CreatedUserProfileDTO>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileBusinessRules _userProfileBusinessRules;

            public CreateUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IMapper mapper, UserProfileBusinessRules userProfileBusinessRules)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
                _userProfileBusinessRules = userProfileBusinessRules;
            }

            public async Task<CreatedUserProfileDTO> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
            {
                await _userProfileBusinessRules.UserProfileEmailMustBeUniqueWhenInserting(request.Email);

                UserProfile mappedUserProfile = _mapper.Map<UserProfile>(request);
                UserProfile createdUserProfile = await _userProfileRepository.AddAsync(mappedUserProfile);

                UserProfile? userProfile = await _userProfileRepository.GetAsync(u => u.Id == createdUserProfile.Id, include: u => u.Include(p => p.Gender));
                CreatedUserProfileDTO createdUserProfileDTO = _mapper.Map<CreatedUserProfileDTO>(userProfile);
                return createdUserProfileDTO;
            }
        }
    }
}
