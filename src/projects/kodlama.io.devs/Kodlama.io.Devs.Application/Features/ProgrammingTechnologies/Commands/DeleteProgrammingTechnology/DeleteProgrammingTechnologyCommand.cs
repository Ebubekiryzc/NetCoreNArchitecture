using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.DTOs;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.DTOs;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology
{
    public class DeleteProgrammingTechnologyCommand : IRequest<DeletedProgrammingTechnologyDTO>
    {
        public int Id { get; set; }

        public class DeleteProgrammingTechnologyCommandHandler : IRequestHandler<DeleteProgrammingTechnologyCommand, DeletedProgrammingTechnologyDTO>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public DeleteProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<DeletedProgrammingTechnologyDTO> Handle(DeleteProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgrammingTechnology? programmingTechnologyToDelete = await _programmingTechnologyRepository.GetAsync(predicate: p => p.Id == request.Id, include: p => p.Include(c => c.ProgrammingLanguage).Include(c => c.ProgrammingTechnologyType));
                _programmingTechnologyBusinessRules.ProgrammingTechnologyMustExistWhenRequested(programmingTechnologyToDelete);

                ProgrammingTechnology deletedProgrammingTechnology = await _programmingTechnologyRepository.DeleteAsync(programmingTechnologyToDelete);
                DeletedProgrammingTechnologyDTO deletedProgrammingTechnologyDTO = _mapper.Map<DeletedProgrammingTechnologyDTO>(deletedProgrammingTechnology);
                return deletedProgrammingTechnologyDTO;
            }
        }
    }
}
