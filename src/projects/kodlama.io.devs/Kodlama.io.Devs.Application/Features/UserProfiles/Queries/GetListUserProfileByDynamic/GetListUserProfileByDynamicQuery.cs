using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfiles.Models;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Queries.GetListUserProfileByDynamic
{
    public class GetListUserProfileByDynamicQuery : IRequest<UserProfileListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequestInstance { get; set; }

        public class GetListUserProfileByDynamicQueryHandler : IRequestHandler<GetListUserProfileByDynamicQuery, UserProfileListModel>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;

            public GetListUserProfileByDynamicQueryHandler(IUserProfileRepository userProfileRepository, IMapper mapper)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
            }

            public async Task<UserProfileListModel> Handle(GetListUserProfileByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserProfile> userProfiles = await _userProfileRepository.GetListByDynamicAsync(index: request.PageRequestInstance.Page, size: request.PageRequestInstance.PageSize, dynamic: request.Dynamic, include: u => u.Include(p => p.Gender));
                UserProfileListModel userProfileListModel = _mapper.Map<UserProfileListModel>(userProfiles);
                return userProfileListModel;
            }
        }
    }
}
