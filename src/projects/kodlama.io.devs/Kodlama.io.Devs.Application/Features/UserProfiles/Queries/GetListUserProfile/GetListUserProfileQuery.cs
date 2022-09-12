using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfiles.Models;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Queries.GetListUserProfile
{
    public class GetListUserProfileQuery : IRequest<UserProfileListModel>
    {
        public PageRequest PageRequestInstance { get; set; }

        public class GetListUserProfileQueryHandler : IRequestHandler<GetListUserProfileQuery, UserProfileListModel>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;

            public GetListUserProfileQueryHandler(IUserProfileRepository userProfileRepository, IMapper mapper)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
            }

            public async Task<UserProfileListModel> Handle(GetListUserProfileQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserProfile> userProfiles = await _userProfileRepository.GetListAsync(index: request.PageRequestInstance.Page, size: request.PageRequestInstance.PageSize, include: u => u.Include(p => p.Gender));
                UserProfileListModel userProfileListModel = _mapper.Map<UserProfileListModel>(userProfiles);
                return userProfileListModel;
            }
        }
    }
}
