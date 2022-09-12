using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Models;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Queries.GetListProgrammingTechnologyTypeByDynamic
{
    public class GetListProgrammingTechnologyTypeByDynamicQuery : IRequest<ProgrammingTechnologyTypeListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequestInstance { get; set; }

        public class GetListProgrammingTechnologyTypeByDynamicQueryHandler : IRequestHandler<GetListProgrammingTechnologyTypeByDynamicQuery, ProgrammingTechnologyTypeListModel>
        {
            private readonly IProgrammingTechnologyTypeRepository _programmingTechnologyTypeRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingTechnologyTypeByDynamicQueryHandler(IProgrammingTechnologyTypeRepository programmingTechnologyTypeRepository, IMapper mapper)
            {
                _programmingTechnologyTypeRepository = programmingTechnologyTypeRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingTechnologyTypeListModel> Handle(GetListProgrammingTechnologyTypeByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingTechnologyType> programmingTechnologyTypes = await _programmingTechnologyTypeRepository.GetListByDynamicAsync(index: request.PageRequestInstance.Page, size: request.PageRequestInstance.PageSize, dynamic: request.Dynamic);
                ProgrammingTechnologyTypeListModel programmingTechnologyTypeListModel = _mapper.Map<ProgrammingTechnologyTypeListModel>(programmingTechnologyTypes);
                return programmingTechnologyTypeListModel;
            }
        }
    }
}
