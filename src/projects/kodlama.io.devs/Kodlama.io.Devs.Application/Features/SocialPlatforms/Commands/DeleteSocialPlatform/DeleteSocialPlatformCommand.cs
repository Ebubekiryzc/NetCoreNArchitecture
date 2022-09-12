using AutoMapper;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.DTOs;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.DeleteSocialPlatform
{
    public class DeleteSocialPlatformCommand : IRequest<DeletedSocialPlatformDTO>
    {
        public int Id { get; set; }

        public class DeleteSocialPlatformCommandHandler : IRequestHandler<DeleteSocialPlatformCommand, DeletedSocialPlatformDTO>
        {
            private readonly ISocialPlatformRepository _socialPlatformRepository;
            private readonly IMapper _mapper;
            private readonly SocialPlatformBusinessRules _socialPlatformBusinessRules;

            public DeleteSocialPlatformCommandHandler(ISocialPlatformRepository socialPlatformRepository, IMapper mapper, SocialPlatformBusinessRules socialPlatformBusinessRules)
            {
                _socialPlatformRepository = socialPlatformRepository;
                _mapper = mapper;
                _socialPlatformBusinessRules = socialPlatformBusinessRules;
            }

            public async Task<DeletedSocialPlatformDTO> Handle(DeleteSocialPlatformCommand request, CancellationToken cancellationToken)
            {
                SocialPlatform? socialPlatformToDelete = await _socialPlatformRepository.GetAsync(s => s.Id == request.Id);
                _socialPlatformBusinessRules.SocialPlatformMustExistWhenRequested(socialPlatformToDelete);

                SocialPlatform deletedSocialPlatform = await _socialPlatformRepository.DeleteAsync(socialPlatformToDelete);
                DeletedSocialPlatformDTO deletedSocialPlatformDTO = _mapper.Map<DeletedSocialPlatformDTO>(deletedSocialPlatform);
                return deletedSocialPlatformDTO;
            }
        }
    }
}
