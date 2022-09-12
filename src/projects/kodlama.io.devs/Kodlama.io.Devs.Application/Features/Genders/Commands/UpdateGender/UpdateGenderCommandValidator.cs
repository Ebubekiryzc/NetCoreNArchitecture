using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Genders.Commands.UpdateGender
{
    public class UpdateGenderCommandValidator: AbstractValidator<UpdateGenderCommand>
    {
        public UpdateGenderCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
