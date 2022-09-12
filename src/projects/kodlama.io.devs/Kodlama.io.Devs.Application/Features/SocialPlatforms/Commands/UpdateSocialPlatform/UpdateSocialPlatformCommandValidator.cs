using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.UpdateSocialPlatform
{
    public class UpdateSocialPlatformCommandValidator : AbstractValidator<UpdateSocialPlatformCommand>
    {
        public UpdateSocialPlatformCommandValidator()
        {
            RuleFor(s => s.Id).NotNull();
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Domain).NotEmpty();
        }
    }
}
