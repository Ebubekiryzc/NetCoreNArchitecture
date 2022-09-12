using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Commands.CreateUserProfileSocialPlatform;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Commands.DeleteUserProfileSocialPlatform;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Commands.UpdateUserProfileSocialPlatform;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.DTOs;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserProfileSocialPlatform, CreateUserProfileSocialPlatformCommand>().ReverseMap();
            CreateMap<UserProfileSocialPlatform, CreatedUserProfileSocialPlatformDTO>()
                .ForMember(u => u.UserFullName, opt => opt.MapFrom(o => o.UserProfile.FirstName.Concat(o.UserProfile.LastName)))
                .ForMember(u => u.PlatformName, opt => opt.MapFrom(o => o.SocialPlatform.Name))
                .ReverseMap();

            CreateMap<UserProfileSocialPlatform, UpdateUserProfileSocialPlatformCommand>().ReverseMap();
            CreateMap<UserProfileSocialPlatform, UpdatedUserProfileSocialPlatformDTO>()
                .ForMember(u => u.UserFullName, opt => opt.MapFrom(o => o.UserProfile.FirstName.Concat(o.UserProfile.LastName)))
                .ForMember(u => u.PlatformName, opt => opt.MapFrom(o => o.SocialPlatform.Name))
                .ReverseMap();

            CreateMap<UserProfileSocialPlatform, DeleteUserProfileSocialPlatformCommand>().ReverseMap();
            CreateMap<UserProfileSocialPlatform, DeletedUserProfileSocialPlatformDTO>()
                .ForMember(u => u.UserFullName, opt => opt.MapFrom(o => o.UserProfile.FirstName.Concat(o.UserProfile.LastName)))
                .ForMember(u => u.PlatformName, opt => opt.MapFrom(o => o.SocialPlatform.Name))
                .ReverseMap();

            CreateMap<UserProfileSocialPlatform, UserProfileSocialPlatformGetByIdDTO>()
                .ForMember(u => u.UserFullName, opt => opt.MapFrom(o => o.UserProfile.FirstName.Concat(o.UserProfile.LastName)))
                .ForMember(u => u.PlatformName, opt => opt.MapFrom(o => o.SocialPlatform.Name))
                .ReverseMap();

            CreateMap<UserProfileSocialPlatform, UserProfileSocialPlatformListDTO>()
                .ForMember(u => u.UserFullName, opt => opt.MapFrom(o => o.UserProfile.FirstName.Concat(o.UserProfile.LastName)))
                .ForMember(u => u.PlatformName, opt => opt.MapFrom(o => o.SocialPlatform.Name))
                .ReverseMap();

            CreateMap<IPaginate<UserProfileSocialPlatform>, UserProfileSocialPlatformListModel>().ReverseMap();
        }
    }
}
