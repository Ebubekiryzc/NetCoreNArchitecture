using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.DTOs;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.CreateProgrammingTechnologyType
{
    public class CreateProgrammingTechnologyTypeCommand : IRequest<CreatedProgrammingTechnologyTypeDTO>
    {
        public string Name { get; set; }

        public class CreateProgrammingTechnologyTypeCommandHandler : IRequestHandler<CreateProgrammingTechnologyTypeCommand, CreatedProgrammingTechnologyTypeDTO>
        {
            private readonly IProgrammingTechnologyTypeRepository _programmingTechnologyTypeRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyTypeBusinessRules _programmingTechnologyTypeBusinessRules;

            public CreateProgrammingTechnologyTypeCommandHandler(IProgrammingTechnologyTypeRepository programmingTechnologyTypeRepository, IMapper mapper, ProgrammingTechnologyTypeBusinessRules programmingTechnologyTypeBusinessRules)
            {
                _programmingTechnologyTypeRepository = programmingTechnologyTypeRepository;
                _mapper = mapper;
                _programmingTechnologyTypeBusinessRules = programmingTechnologyTypeBusinessRules;
            }

            public async Task<CreatedProgrammingTechnologyTypeDTO> Handle(CreateProgrammingTechnologyTypeCommand request, CancellationToken cancellationToken)
            {
                await _programmingTechnologyTypeBusinessRules.ProgrammingTechnologyTypeNameMustBeUniqueWhenInserting(request.Name);

                ProgrammingTechnologyType mappedProgrammingTechnologyType = _mapper.Map<ProgrammingTechnologyType>(request);
                ProgrammingTechnologyType createdProgrammingTechnologyType = await _programmingTechnologyTypeRepository.AddAsync(mappedProgrammingTechnologyType);
                CreatedProgrammingTechnologyTypeDTO createdProgrammingTechnologyTypeDTO = _mapper.Map<CreatedProgrammingTechnologyTypeDTO>(createdProgrammingTechnologyType);
                return createdProgrammingTechnologyTypeDTO;
            }
        }
    }
}