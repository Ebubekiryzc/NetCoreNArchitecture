using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.DTOs;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.UpdateProgrammingTechnologyType
{
    public class UpdateProgrammingTechnologyTypeCommand : IRequest<UpdatedProgrammingTechnologyTypeDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgrammingTechnologyTypeCommandHandler : IRequestHandler<UpdateProgrammingTechnologyTypeCommand, UpdatedProgrammingTechnologyTypeDTO>
        {
            private readonly IProgrammingTechnologyTypeRepository _programmingTechnologyTypeRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyTypeBusinessRules _programmingTechnologyTypeBusinessRules;

            public UpdateProgrammingTechnologyTypeCommandHandler(IProgrammingTechnologyTypeRepository programmingTechnologyTypeRepository, IMapper mapper, ProgrammingTechnologyTypeBusinessRules programmingTechnologyTypeBusinessRules)
            {
                _programmingTechnologyTypeRepository = programmingTechnologyTypeRepository;
                _mapper = mapper;
                _programmingTechnologyTypeBusinessRules = programmingTechnologyTypeBusinessRules;
            }

            public async Task<UpdatedProgrammingTechnologyTypeDTO> Handle(UpdateProgrammingTechnologyTypeCommand request, CancellationToken cancellationToken)
            {
                await _programmingTechnologyTypeBusinessRules.ProgrammingTechnologyTypeMustExistWhenRequested(request.Id);
                await _programmingTechnologyTypeBusinessRules.ProgrammingTechnologyTypeNameMustBeUniqueWhenUpdating(request.Id, request.Name);

                ProgrammingTechnologyType mappedProgrammingTechnologyType = _mapper.Map<ProgrammingTechnologyType>(request);
                ProgrammingTechnologyType updatedProgrammingTechnologyType = await _programmingTechnologyTypeRepository.UpdateAsync(mappedProgrammingTechnologyType);
                UpdatedProgrammingTechnologyTypeDTO updatedProgrammingTechnologyTypeDTO = _mapper.Map<UpdatedProgrammingTechnologyTypeDTO>(updatedProgrammingTechnologyType);
                return updatedProgrammingTechnologyTypeDTO;
            }
        }
    }
}
