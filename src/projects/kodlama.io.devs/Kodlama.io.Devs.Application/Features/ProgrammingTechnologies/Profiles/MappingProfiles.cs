using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.DTOs;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingTechnology, CreatedProgrammingTechnologyDTO>()
                .ForMember(p => p.ProgrammingLanguageName, opt => opt.MapFrom(p => p.ProgrammingLanguage.Name))
                .ForMember(p => p.ProgrammingTechnologyTypeName, opt => opt.MapFrom(p => p.ProgrammingTechnologyType.Name))
                .ReverseMap();

            CreateMap<ProgrammingTechnology, CreateProgrammingTechnologyCommand>().ReverseMap();

            CreateMap<ProgrammingTechnology, UpdatedProgrammingTechnologyDTO>()
                .ForMember(p => p.ProgrammingLanguageName, opt => opt.MapFrom(p => p.ProgrammingLanguage.Name))
                .ForMember(p => p.ProgrammingTechnologyTypeName, opt => opt.MapFrom(p => p.ProgrammingTechnologyType.Name))
                .ReverseMap();

            CreateMap<ProgrammingTechnology, UpdateProgrammingTechnologyCommand>().ReverseMap();

            CreateMap<ProgrammingTechnology, DeletedProgrammingTechnologyDTO>()
                .ForMember(p => p.ProgrammingLanguageName, opt => opt.MapFrom(p => p.ProgrammingLanguage.Name))
                .ForMember(p => p.ProgrammingTechnologyTypeName, opt => opt.MapFrom(p => p.ProgrammingTechnologyType.Name))
                .ReverseMap();

            CreateMap<ProgrammingTechnology, DeleteProgrammingTechnologyCommand>().ReverseMap();

            CreateMap<ProgrammingTechnology, ProgrammingTechnologyGetByIdDTO>()
                .ForMember(p => p.ProgrammingLanguageName, opt => opt.MapFrom(p => p.ProgrammingLanguage.Name))
                .ForMember(p => p.ProgrammingTechnologyTypeName, opt => opt.MapFrom(p => p.ProgrammingTechnologyType.Name))
                .ReverseMap();


            CreateMap<ProgrammingTechnology, ProgrammingTechnologyListDTO>()
                .ForMember(p => p.ProgrammingLanguageName, opt => opt.MapFrom(p => p.ProgrammingLanguage.Name))
                .ForMember(p => p.ProgrammingTechnologyTypeName, opt => opt.MapFrom(p => p.ProgrammingTechnologyType.Name))
                .ReverseMap();

            CreateMap<IPaginate<ProgrammingTechnology>, ProgrammingTechnologyListModel>().ReverseMap();
        }
    }
}
