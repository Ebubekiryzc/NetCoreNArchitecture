using AutoMapper;
using Kodlama.io.Devs.Application.Features.Genders.DTOs;
using Kodlama.io.Devs.Application.Features.Genders.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Genders.Commands.CreateGender
{
    public class CreateGenderCommand : IRequest<CreatedGenderDTO>
    {
        public string Name { get; set; }

        public class CreateGenderCommandHandler : IRequestHandler<CreateGenderCommand, CreatedGenderDTO>
        {
            private readonly IGenderRepository _genderRepository;
            private readonly IMapper _mapper;
            private readonly GenderBusinessRules _genderBusinessRules;

            public CreateGenderCommandHandler(IGenderRepository genderRepository, IMapper mapper, GenderBusinessRules genderBusinessRules)
            {
                _genderRepository = genderRepository;
                _mapper = mapper;
                _genderBusinessRules = genderBusinessRules;
            }

            public async Task<CreatedGenderDTO> Handle(CreateGenderCommand request, CancellationToken cancellationToken)
            {
                await _genderBusinessRules.GenderNameMustBeUniqueWhenInserting(request.Name);

                Gender gender = _mapper.Map<Gender>(request);
                Gender createdGender = await _genderRepository.AddAsync(gender);
                CreatedGenderDTO createdGenderDTO = _mapper.Map<CreatedGenderDTO>(createdGender);
                return createdGenderDTO;
            }
        }
    }
}
