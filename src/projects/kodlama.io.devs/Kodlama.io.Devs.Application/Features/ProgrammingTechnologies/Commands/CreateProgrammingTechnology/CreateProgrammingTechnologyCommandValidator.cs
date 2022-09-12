using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyCommandValidator : AbstractValidator<CreateProgrammingTechnologyCommand>
    {
        public CreateProgrammingTechnologyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.ProgrammingLanguageId).NotNull();
            RuleFor(c => c.ProgrammingTechnologyTypeId).NotNull();
        }
    }
}
