using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authentication.DTOs;
using Kodlama.io.Devs.Application.Features.Authentication.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authentication.Commands.RegisterUser
{
    public class RegisterCommand : IRequest<CreatedAccessTokenDTO>
    {
        public RegisterUserDTO RegisterUserDTOInstance { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, CreatedAccessTokenDTO>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly IMapper _mapper;
            private readonly AuthenticationBusinessRules _authenticationBusinessRules;

            public RegisterCommandHandler(IUserProfileRepository userProfileRepository, IUserOperationClaimRepository userOperationClaimRepository, IOperationClaimRepository operationClaimRepository, ITokenHelper tokenHelper, IMapper mapper, AuthenticationBusinessRules authenticationBusinessRules)
            {
                _userProfileRepository = userProfileRepository;
                _userOperationClaimRepository = userOperationClaimRepository;
                _operationClaimRepository = operationClaimRepository;
                _tokenHelper = tokenHelper;
                _mapper = mapper;
                _authenticationBusinessRules = authenticationBusinessRules;
            }

            public async Task<CreatedAccessTokenDTO> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authenticationBusinessRules.AuthenticationEmailMustBeUniqueWhenRegister(request.RegisterUserDTOInstance.Email);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.RegisterUserDTOInstance.Password, out passwordHash, out passwordSalt);
                UserProfile mappedUserProfile = _mapper.Map<UserProfile>(request.RegisterUserDTOInstance);
                mappedUserProfile.PasswordHash = passwordHash;
                mappedUserProfile.PasswordSalt = passwordSalt;
                mappedUserProfile.Status = true;
                UserProfile createdUserProfile = await _userProfileRepository.AddAsync(mappedUserProfile);

                const string userRoleName = "User";
                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Name == userRoleName);
                UserOperationClaim userOperationClaim = new UserOperationClaim { OperationClaimId = operationClaim.Id, UserId = createdUserProfile.Id };
                await _userOperationClaimRepository.AddAsync(userOperationClaim);

                AccessToken accessToken = _tokenHelper.CreateToken(createdUserProfile, new List<OperationClaim> { operationClaim });
                CreatedAccessTokenDTO createdAccessTokenDTO = _mapper.Map<CreatedAccessTokenDTO>(accessToken);
                return createdAccessTokenDTO;
            }
        }
    }
}
