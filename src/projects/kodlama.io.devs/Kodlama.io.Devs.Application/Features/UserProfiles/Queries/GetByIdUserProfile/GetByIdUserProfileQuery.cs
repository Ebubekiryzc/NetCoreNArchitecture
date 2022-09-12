using AutoMapper;
using Kodlama.io.Devs.Application.Features.UserProfiles.DTOs;
using Kodlama.io.Devs.Application.Features.UserProfiles.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Queries.GetByIdUserProfile
{
    public class GetByIdUserProfileQuery : IRequest<UserProfileGetByIdDTO>
    {
        public int Id { get; set; }

        public class GetByIdUserProfileQueryHandler : IRequestHandler<GetByIdUserProfileQuery, UserProfileGetByIdDTO>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileBusinessRules _userProfileBusinessRules;

            public GetByIdUserProfileQueryHandler(IUserProfileRepository userProfileRepository, IMapper mapper, UserProfileBusinessRules userProfileBusinessRules)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
                _userProfileBusinessRules = userProfileBusinessRules;
            }

            public async Task<UserProfileGetByIdDTO> Handle(GetByIdUserProfileQuery request, CancellationToken cancellationToken)
            {
                UserProfile? userProfile = await _userProfileRepository.GetAsync(u => u.Id == request.Id, include: u=> u.Include(p => p.Gender));
                _userProfileBusinessRules.UserProfileMustExistWhenRequested(userProfile);

                UserProfileGetByIdDTO userProfileGetByIdDTO = _mapper.Map<UserProfileGetByIdDTO>(userProfile);
                return userProfileGetByIdDTO;
            }
        }
    }
}
