using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyCommandValidator: AbstractValidator<UpdateProgrammingTechnologyCommand>
    {
        public UpdateProgrammingTechnologyCommandValidator()
        {
            RuleFor(c => c.Id).NotNull();
            RuleFor(c => c.ProgrammingLanguageId).NotNull();
            RuleFor(c => c.ProgrammingTechnologyTypeId).NotNull();
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
