using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Models;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Queries.GetListUserProfileSocialPlatformByDynamic
{
    public class GetListUserProfileSocialPlatformByDynamicQuery : IRequest<UserProfileSocialPlatformListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequestInstance { get; set; }

        public class GetListUserProfileSocialPlatformByDynamicQueryHandler : IRequestHandler<GetListUserProfileSocialPlatformByDynamicQuery, UserProfileSocialPlatformListModel>
        {
            private readonly IUserProfileSocialPlatformRepository _userProfileSocialPlatformRepository;
            private readonly IMapper _mapper;

            public GetListUserProfileSocialPlatformByDynamicQueryHandler(IUserProfileSocialPlatformRepository userProfileSocialPlatformRepository, IMapper mapper)
            {
                _userProfileSocialPlatformRepository = userProfileSocialPlatformRepository;
                _mapper = mapper;
            }

            public async Task<UserProfileSocialPlatformListModel> Handle(GetListUserProfileSocialPlatformByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserProfileSocialPlatform> userProfileSocialPlatforms = await _userProfileSocialPlatformRepository.GetListByDynamicAsync(index: request.PageRequestInstance.Page, size: request.PageRequestInstance.PageSize, dynamic: request.Dynamic, include: u => u.Include(p => p.SocialPlatform).Include(p => p.UserProfile));
                UserProfileSocialPlatformListModel userProfileSocialPlatformListModel = _mapper.Map<UserProfileSocialPlatformListModel>(userProfileSocialPlatforms);
                return userProfileSocialPlatformListModel;
            }
        }
    }
}
