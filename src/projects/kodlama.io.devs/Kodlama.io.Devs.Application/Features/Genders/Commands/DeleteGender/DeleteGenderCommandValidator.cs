using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Genders.Commands.DeleteGender
{
    public class DeleteGenderCommandValidator : AbstractValidator<DeleteGenderCommand>
    {
        public DeleteGenderCommandValidator()
        {
            RuleFor(g => g.Id).NotNull();
        }
    }
}
