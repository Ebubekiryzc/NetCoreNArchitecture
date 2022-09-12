using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.CreateProgrammingTechnologyType
{
    public class CreateProgrammingTechnologyTypeCommandValidator : AbstractValidator<CreateProgrammingTechnologyTypeCommand>
    {
        public CreateProgrammingTechnologyTypeCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
