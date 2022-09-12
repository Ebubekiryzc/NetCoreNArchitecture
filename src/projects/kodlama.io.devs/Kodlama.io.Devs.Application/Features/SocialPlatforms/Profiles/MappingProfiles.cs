using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.CreateSocialPlatform;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.DeleteSocialPlatform;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.UpdateSocialPlatform;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.DTOs;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.SocialPlatforms.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialPlatform, CreateSocialPlatformCommand>().ReverseMap();
            CreateMap<SocialPlatform, CreatedSocialPlatformDTO>().ReverseMap();
            CreateMap<SocialPlatform, UpdateSocialPlatformCommand>().ReverseMap();
            CreateMap<SocialPlatform, UpdatedSocialPlatformDTO>().ReverseMap();
            CreateMap<SocialPlatform, DeleteSocialPlatformCommand>().ReverseMap();
            CreateMap<SocialPlatform, DeletedSocialPlatformDTO>().ReverseMap();
            CreateMap<SocialPlatform, SocialPlatformGetByIdDTO>().ReverseMap();
            CreateMap<SocialPlatform, SocialPlatformListDTO>().ReverseMap();
            CreateMap<IPaginate<SocialPlatform>, SocialPlatformListModel>().ReverseMap();
        }
    }
}
