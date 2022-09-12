using AutoMapper;
using Kodlama.io.Devs.Application.Features.Genders.DTOs;
using Kodlama.io.Devs.Application.Features.Genders.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Genders.Commands.UpdateGender
{
    public class UpdateGenderCommand : IRequest<UpdatedGenderDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateGenderCommandHandler : IRequestHandler<UpdateGenderCommand, UpdatedGenderDTO>
        {
            private readonly IGenderRepository _genderRepository;
            private readonly IMapper _mapper;
            private readonly GenderBusinessRules _genderBusinessRules;

            public UpdateGenderCommandHandler(IGenderRepository genderRepository, IMapper mapper, GenderBusinessRules genderBusinessRules)
            {
                _genderRepository = genderRepository;
                _mapper = mapper;
                _genderBusinessRules = genderBusinessRules;
            }

            public async Task<UpdatedGenderDTO> Handle(UpdateGenderCommand request, CancellationToken cancellationToken)
            {
                await _genderBusinessRules.GenderMustExistWhenRequested(request.Id);
                await _genderBusinessRules.GenderNameMustBeUniqueWhenUpdating(request.Id, request.Name);

                Gender gender = _mapper.Map<Gender>(request);
                Gender updatedGender = await _genderRepository.UpdateAsync(gender);
                UpdatedGenderDTO updatedGenderDTO = _mapper.Map<UpdatedGenderDTO>(updatedGender);
                return updatedGenderDTO;
            }
        }
    }
}
