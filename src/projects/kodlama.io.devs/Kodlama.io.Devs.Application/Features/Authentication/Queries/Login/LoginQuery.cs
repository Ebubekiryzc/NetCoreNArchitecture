using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authentication.DTOs;
using Kodlama.io.Devs.Application.Features.Authentication.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.Authentication.Queries.LoginUser
{
    public class LoginQuery : IRequest<CreatedAccessTokenDTO>
    {
        public UserForLoginDto LoginDTO { get; set; }

        public class LoginQueryHandler : IRequestHandler<LoginQuery, CreatedAccessTokenDTO>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly IMapper _mapper;
            private readonly AuthenticationBusinessRules _authenticationBusinessRules;

            public LoginQueryHandler(IUserProfileRepository userProfileRepository, ITokenHelper tokenHelper, IMapper mapper, AuthenticationBusinessRules authenticationBusinessRules)
            {
                _userProfileRepository = userProfileRepository;
                _tokenHelper = tokenHelper;
                _mapper = mapper;
                _authenticationBusinessRules = authenticationBusinessRules;
            }

            public async Task<CreatedAccessTokenDTO> Handle(LoginQuery request, CancellationToken cancellationToken)
            {
                UserProfile? userProfile = await _userProfileRepository.GetAsync(u => u.Email == request.LoginDTO.Email,
                    include: p => p.Include(up => up.UserOperationClaims).ThenInclude(x => x.OperationClaim));

                _authenticationBusinessRules.AuthenticationUserProfileMustExistWhenLogin(userProfile);
                _authenticationBusinessRules.AuthenticationCredentialsMustMatchWhenLogin(request.LoginDTO.Password, userProfile.PasswordHash, userProfile.PasswordSalt);

                List<OperationClaim> operationClaims = userProfile.UserOperationClaims.Select(o => o.OperationClaim).ToList();

                AccessToken accessToken = _tokenHelper.CreateToken(userProfile, operationClaims);
                CreatedAccessTokenDTO createdAccessTokenDTO = _mapper.Map<CreatedAccessTokenDTO>(accessToken);
                return createdAccessTokenDTO;
            }
        }
    }
}
