using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Genders.Commands.CreateGender
{
    public class CreateGenderCommandValidator : AbstractValidator<CreateGenderCommand>
    {
        public CreateGenderCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
