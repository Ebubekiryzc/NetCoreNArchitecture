using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.DTOs;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyCommand : IRequest<CreatedProgrammingTechnologyDTO>
    {
        public int ProgrammingLanguageId { get; set; }
        public int ProgrammingTechnologyTypeId { get; set; }
        public string Name { get; set; }

        public class CreateProgrammingTechnologyCommandHandler : IRequestHandler<CreateProgrammingTechnologyCommand, CreatedProgrammingTechnologyDTO>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public CreateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<CreatedProgrammingTechnologyDTO> Handle(CreateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                // await _programmingTechnologyBusinessRules.ProgrammingTechnologyNameMustBeUniqueWhenInserting(request.Name);

                ProgrammingTechnology mappedProgrammingTechnology = _mapper.Map<ProgrammingTechnology>(request);
                ProgrammingTechnology createdProgrammingTechnology = await _programmingTechnologyRepository.AddAsync(mappedProgrammingTechnology);

                ProgrammingTechnology? createdProgrammingTechnologyWithReferences = await _programmingTechnologyRepository.GetAsync(predicate: p => p.Id == createdProgrammingTechnology.Id, include: p => p.Include(c => c.ProgrammingLanguage).Include(c => c.ProgrammingTechnologyType));
                CreatedProgrammingTechnologyDTO createdProgrammingTechnologyDTO = _mapper.Map<CreatedProgrammingTechnologyDTO>(createdProgrammingTechnologyWithReferences);
                return createdProgrammingTechnologyDTO;
            }
        }
    }
}
