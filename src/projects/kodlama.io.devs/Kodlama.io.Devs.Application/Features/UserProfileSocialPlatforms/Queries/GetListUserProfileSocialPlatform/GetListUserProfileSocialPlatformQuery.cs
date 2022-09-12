using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Models;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Queries.GetListUserProfileSocialPlatform
{
    public class GetListUserProfileSocialPlatformQuery : IRequest<UserProfileSocialPlatformListModel>
    {
        public PageRequest PageRequestInstance { get; set; }

        public class GetListUserProfileSocialPlatformQueryHandler : IRequestHandler<GetListUserProfileSocialPlatformQuery, UserProfileSocialPlatformListModel>
        {
            private readonly IUserProfileSocialPlatformRepository _userProfileSocialPlatformRepository;
            private readonly IMapper _mapper;

            public GetListUserProfileSocialPlatformQueryHandler(IUserProfileSocialPlatformRepository userProfileSocialPlatformRepository, IMapper mapper)
            {
                _userProfileSocialPlatformRepository = userProfileSocialPlatformRepository;
                _mapper = mapper;
            }

            public async Task<UserProfileSocialPlatformListModel> Handle(GetListUserProfileSocialPlatformQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserProfileSocialPlatform> userProfileSocialPlatforms = await _userProfileSocialPlatformRepository.GetListAsync(index: request.PageRequestInstance.Page, size: request.PageRequestInstance.PageSize, include: u => u.Include(p => p.SocialPlatform).Include(p => p.UserProfile));
                UserProfileSocialPlatformListModel userProfileSocialPlatformListModel = _mapper.Map<UserProfileSocialPlatformListModel>(userProfileSocialPlatforms);
                return userProfileSocialPlatformListModel;
            }
        }
    }
}
