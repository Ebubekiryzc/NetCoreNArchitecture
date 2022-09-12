using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.DTOs;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.DeleteProgrammingTechnologyType
{
    public class DeleteProgrammingTechnologyTypeCommand : IRequest<DeletedProgrammingTechnologyTypeDTO>
    {
        public int Id { get; set; }

        public class DeleteProgrammingTechnologyTypeCommandHandler : IRequestHandler<DeleteProgrammingTechnologyTypeCommand, DeletedProgrammingTechnologyTypeDTO>
        {
            private readonly IProgrammingTechnologyTypeRepository _programmingTechnologyTypeRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyTypeBusinessRules _programmingTechnologyTypeBusinessRules;

            public DeleteProgrammingTechnologyTypeCommandHandler(IProgrammingTechnologyTypeRepository programmingTechnologyTypeRepository, IMapper mapper, ProgrammingTechnologyTypeBusinessRules programmingTechnologyTypeBusinessRules)
            {
                _programmingTechnologyTypeRepository = programmingTechnologyTypeRepository;
                _mapper = mapper;
                _programmingTechnologyTypeBusinessRules = programmingTechnologyTypeBusinessRules;
            }

            public async Task<DeletedProgrammingTechnologyTypeDTO> Handle(DeleteProgrammingTechnologyTypeCommand request, CancellationToken cancellationToken)
            {
                ProgrammingTechnologyType? programmingTechnologyTypeToDelete = await _programmingTechnologyTypeRepository.GetAsync(p => p.Id == request.Id);
                _programmingTechnologyTypeBusinessRules.ProgrammingTechnologyTypeMustExistWhenRequested(programmingTechnologyTypeToDelete);

                ProgrammingTechnologyType deletedProgrammingTechnologyType = await _programmingTechnologyTypeRepository.DeleteAsync(programmingTechnologyTypeToDelete);
                DeletedProgrammingTechnologyTypeDTO deletedProgrammingTechnologyTypeDTO = _mapper.Map<DeletedProgrammingTechnologyTypeDTO>(deletedProgrammingTechnologyType);
                return deletedProgrammingTechnologyTypeDTO;
            }
        }
    }
}
