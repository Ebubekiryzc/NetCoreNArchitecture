using AutoMapper;
using Kodlama.io.Devs.Application.Features.Genders.DTOs;
using Kodlama.io.Devs.Application.Features.Genders.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Genders.Commands.DeleteGender
{
    public class DeleteGenderCommand : IRequest<DeletedGenderDTO>
    {
        public int Id { get; set; }

        public class DeleteGenderCommandHandler : IRequestHandler<DeleteGenderCommand, DeletedGenderDTO>
        {
            private readonly IGenderRepository _genderRepository;
            private readonly IMapper _mapper;
            private readonly GenderBusinessRules _genderBusinessRules;

            public DeleteGenderCommandHandler(IGenderRepository genderRepository, IMapper mapper, GenderBusinessRules genderBusinessRules)
            {
                _genderRepository = genderRepository;
                _mapper = mapper;
                _genderBusinessRules = genderBusinessRules;
            }

            public async Task<DeletedGenderDTO> Handle(DeleteGenderCommand request, CancellationToken cancellationToken)
            {
                Gender? genderToDelete = await _genderRepository.GetAsync(p => p.Id == request.Id);
                _genderBusinessRules.GenderMustExistWhenRequested(genderToDelete);

                Gender deletedGender = await _genderRepository.DeleteAsync(genderToDelete);
                DeletedGenderDTO deletedGenderDTO = _mapper.Map<DeletedGenderDTO>(deletedGender);
                return deletedGenderDTO;
            }
        }
    }
}
