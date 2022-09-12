using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.CreateSocialPlatform
{
    public class CreateSocialPlatformCommandValidator : AbstractValidator<CreateSocialPlatformCommand>
    {
        public CreateSocialPlatformCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Domain).NotEmpty();
        }
    }
}
