using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Commands.CreateUserProfile
{
    public class CreateUserProfileCommandValidator : AbstractValidator<CreateUserProfileCommand>
    {
        public CreateUserProfileCommandValidator()
        {
            RuleFor(c => c.UserId).NotNull();
            RuleFor(c => c.GenderId).NotNull();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Status).NotNull();
            RuleFor(c => c.DateOfBirth).NotNull();
        }
    }
}
