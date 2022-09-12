using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.UpdateProgrammingTechnologyType
{
    public class UpdateProgrammingTechnologyTypeCommandValidator : AbstractValidator<UpdateProgrammingTechnologyTypeCommand>
    {
        public UpdateProgrammingTechnologyTypeCommandValidator()
        {
            RuleFor(p => p.Id).NotNull();
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
