using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.DTOs;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetByIdProgrammingTechnology
{
    public class GetByIdProgrammingTechnologyQuery : IRequest<ProgrammingTechnologyGetByIdDTO>
    {
        public int Id { get; set; }

        public class GetByIdProgrammingTechnologyQueryHandler : IRequestHandler<GetByIdProgrammingTechnologyQuery, ProgrammingTechnologyGetByIdDTO>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public GetByIdProgrammingTechnologyQueryHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<ProgrammingTechnologyGetByIdDTO> Handle(GetByIdProgrammingTechnologyQuery request, CancellationToken cancellationToken)
            {
                ProgrammingTechnology? programmingTechnology = await _programmingTechnologyRepository.GetAsync(predicate: p => p.Id == request.Id, include: p => p.Include(p => p.ProgrammingLanguage).Include(p => p.ProgrammingTechnologyType));

                _programmingTechnologyBusinessRules.ProgrammingTechnologyMustExistWhenRequested(programmingTechnology);

                ProgrammingTechnologyGetByIdDTO programmingTechnologyGetByIdDTO = _mapper.Map<ProgrammingTechnologyGetByIdDTO>(programmingTechnology);
                return programmingTechnologyGetByIdDTO;
            }
        }
    }
}
