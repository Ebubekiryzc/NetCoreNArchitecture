using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Models;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Queries.GetListProgrammingTechnologyType
{
    public class GetListProgrammingTechnologyTypeQuery : IRequest<ProgrammingTechnologyTypeListModel>
    {
        public PageRequest PageRequestInstance { get; set; }

        public class GetListProgrammingTechnologyTypeQueryHandler : IRequestHandler<GetListProgrammingTechnologyTypeQuery, ProgrammingTechnologyTypeListModel>
        {
            private readonly IProgrammingTechnologyTypeRepository _programmingTechnologyTypeRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingTechnologyTypeQueryHandler(IProgrammingTechnologyTypeRepository programmingTechnologyTypeRepository, IMapper mapper)
            {
                _programmingTechnologyTypeRepository = programmingTechnologyTypeRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingTechnologyTypeListModel> Handle(GetListProgrammingTechnologyTypeQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingTechnologyType> programmingTechnologyTypes = await _programmingTechnologyTypeRepository.GetListAsync(index: request.PageRequestInstance.Page, size: request.PageRequestInstance.PageSize);
                ProgrammingTechnologyTypeListModel programmingTechnologyTypeListModel = _mapper.Map<ProgrammingTechnologyTypeListModel>(programmingTechnologyTypes);
                return programmingTechnologyTypeListModel;
            }
        }
    }
}
