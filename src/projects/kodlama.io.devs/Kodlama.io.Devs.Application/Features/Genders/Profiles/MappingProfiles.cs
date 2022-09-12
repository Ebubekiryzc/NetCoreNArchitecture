using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Genders.Commands.CreateGender;
using Kodlama.io.Devs.Application.Features.Genders.Commands.DeleteGender;
using Kodlama.io.Devs.Application.Features.Genders.Commands.UpdateGender;
using Kodlama.io.Devs.Application.Features.Genders.DTOs;
using Kodlama.io.Devs.Application.Features.Genders.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Genders.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Gender, CreateGenderCommand>().ReverseMap();
            CreateMap<Gender, CreatedGenderDTO>().ReverseMap();
            CreateMap<Gender, UpdateGenderCommand>().ReverseMap();
            CreateMap<Gender, UpdatedGenderDTO>().ReverseMap();
            CreateMap<Gender, DeleteGenderCommand>().ReverseMap();
            CreateMap<Gender, DeletedGenderDTO>().ReverseMap();
            CreateMap<Gender, GenderGetByIdDTO>().ReverseMap();
            CreateMap<Gender, GenderListDTO>().ReverseMap();
            CreateMap<IPaginate<Gender>, GenderListModel>().ReverseMap();
        }
    }
}
