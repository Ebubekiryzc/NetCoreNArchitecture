using AutoMapper;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authentication.DTOs;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Authentication.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserProfile, RegisterUserDTO>().ReverseMap();
            CreateMap<CreatedAccessTokenDTO, AccessToken>().ReverseMap();
        }
    }
}
