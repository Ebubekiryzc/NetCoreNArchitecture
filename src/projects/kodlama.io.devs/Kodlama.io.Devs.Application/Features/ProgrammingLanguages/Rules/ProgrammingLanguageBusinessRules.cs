﻿using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constants;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameMustBeUniqueWhenSaving(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException(ExceptionMessages.ProgrammingLanguageNameExist);
        }
    }
}
