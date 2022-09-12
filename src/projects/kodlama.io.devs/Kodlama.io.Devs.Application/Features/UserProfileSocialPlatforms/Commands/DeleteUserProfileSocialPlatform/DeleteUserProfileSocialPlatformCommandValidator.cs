using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Commands.DeleteUserProfileSocialPlatform
{
    public class DeleteUserProfileSocialPlatformCommandValidator : AbstractValidator<DeleteUserProfileSocialPlatformCommand>
    {
        public DeleteUserProfileSocialPlatformCommandValidator()
        {
            RuleFor(u => u.Id).NotNull();
        }
    }
}
