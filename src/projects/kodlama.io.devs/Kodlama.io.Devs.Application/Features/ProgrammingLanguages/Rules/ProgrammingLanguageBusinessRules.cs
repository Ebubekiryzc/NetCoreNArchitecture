using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constants;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using System.Runtime.Intrinsics.Arm;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameMustBeUniqueWhenInserting(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException(ExceptionMessages.ProgrammingLanguageNameExist);
        }

        public async Task ProgrammingLanguageNameMustBeUniqueWhenUpdating(int id, string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p => p.Id != id && p.Name == name);
            if (result.Items.Any()) throw new BusinessException(ExceptionMessages.ProgrammingLanguageNameExist);
        }

        public async Task ProgrammingLanguageMustExistWhenRequested(int id)
        {
            ProgrammingLanguage result = await _programmingLanguageRepository.GetAsync(p => p.Id == id);
            if (result == null) throw new BusinessException(ExceptionMessages.ProgrammingLanguageIsNull);
        }

        public void ProgrammingLanguageMustExistWhenRequested(ProgrammingLanguage? programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException(ExceptionMessages.ProgrammingLanguageIsNull);
        }
    }
}
