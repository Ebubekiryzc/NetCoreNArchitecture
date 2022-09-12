using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Genders.Models;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Genders.Queries.GetListGenderByDynamic
{
    public class GetListGenderByDynamicQuery : IRequest<GenderListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequestInstance { get; set; }

        public class GetListGenderByDynamicQueryHandler : IRequestHandler<GetListGenderByDynamicQuery, GenderListModel>
        {

            private readonly IGenderRepository _genderRepository;
            private readonly IMapper _mapper;

            public GetListGenderByDynamicQueryHandler(IGenderRepository genderRepository, IMapper mapper)
            {
                _genderRepository = genderRepository;
                _mapper = mapper;
            }

            public async Task<GenderListModel> Handle(GetListGenderByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Gender> genders = await _genderRepository.GetListByDynamicAsync(index: request.PageRequestInstance.Page, size: request.PageRequestInstance.PageSize, dynamic: request.Dynamic);
                GenderListModel genderListModel = _mapper.Map<GenderListModel>(genders);
                return genderListModel;
            }
        }
    }
}
