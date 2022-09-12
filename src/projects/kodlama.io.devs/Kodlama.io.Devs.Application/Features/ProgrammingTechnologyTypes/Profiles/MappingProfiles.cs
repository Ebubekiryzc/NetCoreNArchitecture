using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.CreateProgrammingTechnologyType;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.DeleteProgrammingTechnologyType;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.UpdateProgrammingTechnologyType;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.DTOs;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingTechnologyType, CreatedProgrammingTechnologyTypeDTO>().ReverseMap();
            CreateMap<ProgrammingTechnologyType, CreateProgrammingTechnologyTypeCommand>().ReverseMap();
            CreateMap<ProgrammingTechnologyType, UpdatedProgrammingTechnologyTypeDTO>().ReverseMap();
            CreateMap<ProgrammingTechnologyType, UpdateProgrammingTechnologyTypeCommand>().ReverseMap();
            CreateMap<ProgrammingTechnologyType, DeletedProgrammingTechnologyTypeDTO>().ReverseMap();
            CreateMap<ProgrammingTechnologyType, DeleteProgrammingTechnologyTypeCommand>().ReverseMap();
            CreateMap<ProgrammingTechnologyType, ProgrammingTechnologyTypeGetByIdDTO>().ReverseMap();
            CreateMap<ProgrammingTechnologyType, ProgrammingTechnologyTypeListDTO>().ReverseMap();
            CreateMap<IPaginate<ProgrammingTechnologyType>, ProgrammingTechnologyTypeListModel>().ReverseMap();
        }
    }
}
