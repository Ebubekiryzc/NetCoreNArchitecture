using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Commands.CreateUserProfileSocialPlatform
{
    public class CreateUserProfileSocialPlatformCommandValidator : AbstractValidator<CreateUserProfileSocialPlatformCommand>
    {
        public CreateUserProfileSocialPlatformCommandValidator()
        {
            RuleFor(u => u.UserId).NotNull();
            RuleFor(u => u.SocialPlatformId).NotNull();
            RuleFor(u => u.SocialProfileURI).NotEmpty();
        }
    }
}
