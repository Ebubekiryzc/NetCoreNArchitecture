using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Commands.DeleteUserProfile
{
    public class DeleteUserProfileCommandValidator : AbstractValidator<DeleteUserProfileCommand>
    {
        public DeleteUserProfileCommandValidator()
        {
            RuleFor(c => c.Id).NotNull();
        }
    }
}
