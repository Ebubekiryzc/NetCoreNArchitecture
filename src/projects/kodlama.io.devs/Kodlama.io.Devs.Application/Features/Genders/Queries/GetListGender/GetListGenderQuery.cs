using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Genders.Models;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Genders.Queries.GetListGender
{
    public class GetListGenderQuery : IRequest<GenderListModel>
    {
        public PageRequest PageRequestInstance { get; set; }
        public class GetListGenderQueryHandler : IRequestHandler<GetListGenderQuery, GenderListModel>
        {
            private readonly IGenderRepository _genderRepository;
            private readonly IMapper _mapper;

            public GetListGenderQueryHandler(IGenderRepository genderRepository, IMapper mapper)
            {
                _genderRepository = genderRepository;
                _mapper = mapper;
            }

            public async Task<GenderListModel> Handle(GetListGenderQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Gender> genders = await _genderRepository.GetListAsync(index: request.PageRequestInstance.Page, size: request.PageRequestInstance.PageSize);
                GenderListModel genderListModel = _mapper.Map<GenderListModel>(genders);
                return genderListModel;
            }
        }
    }
}
