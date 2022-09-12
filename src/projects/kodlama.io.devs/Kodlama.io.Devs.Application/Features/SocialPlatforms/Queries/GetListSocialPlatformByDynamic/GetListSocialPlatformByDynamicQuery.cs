using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Models;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.SocialPlatforms.Queries.GetListSocialPlatform
{
    public class GetListSocialPlatformByDynamicQuery : IRequest<SocialPlatformListModel>
    {
        public PageRequest PageRequestInstance { get; set; }
        public Dynamic Dynamic { get; set; }

        public class GetListSocialPlatformQueryHandler : IRequestHandler<GetListSocialPlatformByDynamicQuery, SocialPlatformListModel>
        {
            private readonly ISocialPlatformRepository _socialPlatformRepository;
            private readonly IMapper _mapper;

            public GetListSocialPlatformQueryHandler(ISocialPlatformRepository socialPlatformRepository, IMapper mapper)
            {
                _socialPlatformRepository = socialPlatformRepository;
                _mapper = mapper;
            }

            public async Task<SocialPlatformListModel> Handle(GetListSocialPlatformByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SocialPlatform> socialPlatforms = await _socialPlatformRepository.GetListByDynamicAsync(index: request.PageRequestInstance.Page, size: request.PageRequestInstance.PageSize, dynamic: request.Dynamic);
                SocialPlatformListModel socialPlatformListModel = _mapper.Map<SocialPlatformListModel>(socialPlatforms);
                return socialPlatformListModel;
            }
        }
    }
}
