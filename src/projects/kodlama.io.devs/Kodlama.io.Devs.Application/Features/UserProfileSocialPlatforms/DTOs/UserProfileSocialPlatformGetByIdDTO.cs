namespace Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.DTOs
{
    public class UserProfileSocialPlatformGetByIdDTO
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string PlatformName { get; set; }
        public string ProfileURI { get; set; }

    }
}
