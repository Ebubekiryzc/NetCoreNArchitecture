using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfiles.Commands.CreateUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Commands.DeleteUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Commands.UpdateUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.DTOs;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserProfile, CreateUserProfileCommand>().ReverseMap();
            CreateMap<UserProfile, CreatedUserProfileDTO>()
                .ForMember(u => u.GenderName, opt => opt.MapFrom(o => o.Gender.Name))
                .ReverseMap();

            CreateMap<UserProfile, UpdateUserProfileCommand>().ReverseMap();
            CreateMap<UserProfile, UpdatedUserProfileDTO>()
                .ForMember(u => u.GenderName, opt => opt.MapFrom(o => o.Gender.Name))
                .ReverseMap();

            CreateMap<UserProfile, DeleteUserProfileCommand>().ReverseMap();
            CreateMap<UserProfile, DeletedUserProfileDTO>()
                .ForMember(u => u.GenderName, opt => opt.MapFrom(o => o.Gender.Name))
                .ReverseMap();

            CreateMap<UserProfile, UserProfileGetByIdDTO>()
                .ForMember(u => u.GenderName, opt => opt.MapFrom(o => o.Gender.Name))
                .ReverseMap();

            CreateMap<UserProfile, UserProfileGetByIdDTO>()
                .ForMember(u => u.GenderName, opt => opt.MapFrom(o => o.Gender.Name))
                .ReverseMap();

            CreateMap<IPaginate<UserProfile>, UserProfileGetByIdDTO>().ReverseMap();
        }
    }
}
