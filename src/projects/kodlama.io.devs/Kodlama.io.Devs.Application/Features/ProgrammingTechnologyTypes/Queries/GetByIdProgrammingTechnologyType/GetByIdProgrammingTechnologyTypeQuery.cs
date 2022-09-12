using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.DTOs;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Queries.GetByIdProgrammingTechnologyType
{
    public class GetByIdProgrammingTechnologyTypeQuery : IRequest<ProgrammingTechnologyTypeGetByIdDTO>
    {
        public int Id { get; set; }

        public class GetByIdProgrammingTechnologyTypeQueryHandler : IRequestHandler<GetByIdProgrammingTechnologyTypeQuery, ProgrammingTechnologyTypeGetByIdDTO>
        {
            private readonly IProgrammingTechnologyTypeRepository _programmingTechnologyTypeRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyTypeBusinessRules _programmingTechnologyTypeBusinessRules;

            public GetByIdProgrammingTechnologyTypeQueryHandler(IProgrammingTechnologyTypeRepository programmingTechnologyTypeRepository, IMapper mapper, ProgrammingTechnologyTypeBusinessRules programmingTechnologyTypeBusinessRules)
            {
                _programmingTechnologyTypeRepository = programmingTechnologyTypeRepository;
                _mapper = mapper;
                _programmingTechnologyTypeBusinessRules = programmingTechnologyTypeBusinessRules;
            }

            public async Task<ProgrammingTechnologyTypeGetByIdDTO> Handle(GetByIdProgrammingTechnologyTypeQuery request, CancellationToken cancellationToken)
            {
                ProgrammingTechnologyType? programmingTechnologyType = await _programmingTechnologyTypeRepository.GetAsync(predicate: p => p.Id == request.Id);

                _programmingTechnologyTypeBusinessRules.ProgrammingTechnologyTypeMustExistWhenRequested(programmingTechnologyType);

                ProgrammingTechnologyTypeGetByIdDTO programmingTechnologyTypeGetByIdDTO = _mapper.Map<ProgrammingTechnologyTypeGetByIdDTO>(programmingTechnologyType);
                return programmingTechnologyTypeGetByIdDTO;
            }
        }
    }
}
