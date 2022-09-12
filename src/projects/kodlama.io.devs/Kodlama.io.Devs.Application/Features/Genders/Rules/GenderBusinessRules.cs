using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Genders.Constants;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Genders.Rules
{
    public class GenderBusinessRules
    {
        private readonly IGenderRepository _genderRepository;

        public GenderBusinessRules(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task GenderNameMustBeUniqueWhenInserting(string name)
        {
            IPaginate<Gender> result = await _genderRepository.GetListAsync(g => g.Name == name);
            if (result.Items.Any()) throw new BusinessException(ExceptionMessages.GenderNameExist);
        }

        public async Task GenderNameMustBeUniqueWhenUpdating(int id, string name)
        {
            IPaginate<Gender> result = await _genderRepository.GetListAsync(p => p.Id != id && p.Name == name);
            if (result.Items.Any()) throw new BusinessException(ExceptionMessages.GenderNameExist);
        }

        public async Task GenderMustExistWhenRequested(int id)
        {
            Gender? result = await _genderRepository.GetAsync(p => p.Id == id, enableTracking: false);
            if (result == null) throw new BusinessException(ExceptionMessages.GenderIsNull);
        }

        public void GenderMustExistWhenRequested(Gender? gender)
        {
            if (gender == null) throw new BusinessException(ExceptionMessages.GenderIsNull);
        }
    }
}
