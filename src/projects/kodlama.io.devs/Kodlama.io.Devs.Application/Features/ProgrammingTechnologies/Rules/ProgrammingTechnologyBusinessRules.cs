using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Constants;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules
{
    public class ProgrammingTechnologyBusinessRules
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;

        public ProgrammingTechnologyBusinessRules(IProgrammingTechnologyRepository programmingTechnologyRepository)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
        }

        public async Task ProgrammingTechnologyNameMustBeUniqueWhenInserting(string name)
        {
            IPaginate<ProgrammingTechnology> result = await _programmingTechnologyRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException(ExceptionMessages.ProgrammingTechnologyNameExist);
        }

        public async Task ProgrammingTechnologyNameMustBeUniqueWhenUpdating(int id, string name)
        {
            IPaginate<ProgrammingTechnology> result = await _programmingTechnologyRepository.GetListAsync(p => p.Id != id && p.Name == name);
            if (result.Items.Any()) throw new BusinessException(ExceptionMessages.ProgrammingTechnologyNameExist);
        }

        public async Task ProgrammingTechnologyMustExistWhenRequested(int id)
        {
            ProgrammingTechnology? result = await _programmingTechnologyRepository.GetAsync(p => p.Id == id, enableTracking: false);
            if (result == null) throw new BusinessException(ExceptionMessages.ProgrammingTechnologyIsNull);
        }

        public void ProgrammingTechnologyMustExistWhenRequested(ProgrammingTechnology? programmingTechnology)
        {
            if (programmingTechnology == null) throw new BusinessException(ExceptionMessages.ProgrammingTechnologyIsNull);
        }
    }
}
