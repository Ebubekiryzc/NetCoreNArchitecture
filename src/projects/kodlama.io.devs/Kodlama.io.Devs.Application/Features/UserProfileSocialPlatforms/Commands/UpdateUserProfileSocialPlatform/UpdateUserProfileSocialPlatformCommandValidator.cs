using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Commands.UpdateUserProfileSocialPlatform
{
    public class UpdateUserProfileSocialPlatformCommandValidator : AbstractValidator<UpdateUserProfileSocialPlatformCommand>
    {
        public UpdateUserProfileSocialPlatformCommandValidator()
        {
            RuleFor(u => u.Id).NotNull();
            RuleFor(u => u.UserProfileId).NotNull();
            RuleFor(u => u.SocialPlaformId).NotNull();
            RuleFor(u => u.SocialPlatformURI).NotEmpty();
        }
    }
}
