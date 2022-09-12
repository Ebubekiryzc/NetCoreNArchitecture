using AutoMapper;
using Kodlama.io.Devs.Application.Features.Genders.DTOs;
using Kodlama.io.Devs.Application.Features.Genders.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Genders.Queries.GetByIdGender
{
    public class GetByIdGenderQuery : IRequest<GenderGetByIdDTO>
    {
        public int Id { get; set; }

        public class GetByIdGenderQueryHandler : IRequestHandler<GetByIdGenderQuery, GenderGetByIdDTO>
        {
            private readonly IGenderRepository _genderRepository;
            private readonly IMapper _mapper;
            private readonly GenderBusinessRules _genderBusinessRules;

            public GetByIdGenderQueryHandler(IGenderRepository genderRepository, IMapper mapper, GenderBusinessRules genderBusinessRules)
            {
                _genderRepository = genderRepository;
                _mapper = mapper;
                _genderBusinessRules = genderBusinessRules;
            }

            public async Task<GenderGetByIdDTO> Handle(GetByIdGenderQuery request, CancellationToken cancellationToken)
            {
                Gender? gender = await _genderRepository.GetAsync(p => p.Id == request.Id);
                _genderBusinessRules.GenderMustExistWhenRequested(gender);

                GenderGetByIdDTO genderGetByIdDTO = _mapper.Map<GenderGetByIdDTO>(gender);
                return genderGetByIdDTO;
            }
        }
    }
}
