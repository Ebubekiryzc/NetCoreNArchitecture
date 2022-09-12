using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Constants;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Rules
{
    public class ProgrammingTechnologyTypeBusinessRules
    {
        private readonly IProgrammingTechnologyTypeRepository _programmingTechnologyTypeRepository;

        public ProgrammingTechnologyTypeBusinessRules(IProgrammingTechnologyTypeRepository programmingTechnologyTypeRepository)
        {
            _programmingTechnologyTypeRepository = programmingTechnologyTypeRepository;
        }

        public async Task ProgrammingTechnologyTypeNameMustBeUniqueWhenInserting(string name)
        {
            IPaginate<ProgrammingTechnologyType> result = await _programmingTechnologyTypeRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException(ExceptionMessages.ProgrammingTechnologyTypeNameExist);
        }

        public async Task ProgrammingTechnologyTypeNameMustBeUniqueWhenUpdating(int id, string name)
        {
            IPaginate<ProgrammingTechnologyType> result = await _programmingTechnologyTypeRepository.GetListAsync(p => p.Id != id && p.Name == name);
            if (result.Items.Any()) throw new BusinessException(ExceptionMessages.ProgrammingTechnologyTypeNameExist);
        }

        public async Task ProgrammingTechnologyTypeMustExistWhenRequested(int id)
        {
            ProgrammingTechnologyType? result = await _programmingTechnologyTypeRepository.GetAsync(p => p.Id == id, enableTracking: false);
            if (result == null) throw new BusinessException(ExceptionMessages.ProgrammingTechnologyTypeIsNull);
        }

        public void ProgrammingTechnologyTypeMustExistWhenRequested(ProgrammingTechnologyType? programmingTechnologyType)
        {
            if (programmingTechnologyType == null) throw new BusinessException(ExceptionMessages.ProgrammingTechnologyTypeIsNull);
        }
    }
}
