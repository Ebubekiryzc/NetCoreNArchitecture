using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.DTOs;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyCommand : IRequest<UpdatedProgrammingTechnologyDTO>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public int ProgrammingTechnologyTypeId { get; set; }
        public string Name { get; set; }

        public class UpdateProgrammingTechnologyCommandHandler : IRequestHandler<UpdateProgrammingTechnologyCommand, UpdatedProgrammingTechnologyDTO>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public UpdateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<UpdatedProgrammingTechnologyDTO> Handle(UpdateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                // await _programmingTechnologyBusinessRules.ProgrammingTechnologyNameMustBeUniqueWhenUpdating(request.Id, request.Name);
                await _programmingTechnologyBusinessRules.ProgrammingTechnologyMustExistWhenRequested(request.Id);

                ProgrammingTechnology mappedProgrammingTechnology = _mapper.Map<ProgrammingTechnology>(request);
                ProgrammingTechnology updatedProgrammingTechnology = await _programmingTechnologyRepository.UpdateAsync(mappedProgrammingTechnology);

                ProgrammingTechnology? updatedProgrammingTechnologyWithReferences = await _programmingTechnologyRepository.GetAsync(predicate: p => p.Id == updatedProgrammingTechnology.Id, include: p => p.Include(c => c.ProgrammingLanguage).Include(c => c.ProgrammingTechnologyType));
                UpdatedProgrammingTechnologyDTO updatedProgrammingTechnologyDTO = _mapper.Map<UpdatedProgrammingTechnologyDTO>(updatedProgrammingTechnologyWithReferences);
                return updatedProgrammingTechnologyDTO;
            }
        }
    }
}
