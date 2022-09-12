using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnologyByDynamic
{
    public class GetListProgrammingTechnologyByDynamicQuery : IRequest<ProgrammingTechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequestInstance { get; set; }

        public class GetListProgrammingTechnologyByDynamicQueryHandler : IRequestHandler<GetListProgrammingTechnologyByDynamicQuery, ProgrammingTechnologyListModel>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingTechnologyByDynamicQueryHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingTechnologyListModel> Handle(GetListProgrammingTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingTechnology> programmingTechnologies = await _programmingTechnologyRepository.GetListByDynamicAsync(dynamic: request.Dynamic, index: request.PageRequestInstance.Page, size: request.PageRequestInstance.PageSize, include: p => p.Include(p => p.ProgrammingLanguage).Include(p => p.ProgrammingTechnologyType));
                ProgrammingTechnologyListModel programmingTechnologyListModel = _mapper.Map<ProgrammingTechnologyListModel>(programmingTechnologies);
                return programmingTechnologyListModel;
            }
        }
    }
}
