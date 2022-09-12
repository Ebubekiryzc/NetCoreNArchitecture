using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class UserProfileSocialPlatform : Entity
    {
        public int UserProfileId { get; set; }
        public int SocialPlatformId { get; set; }
        public string SocialProfileURI { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual SocialPlatform SocialPlatform { get; set; }

        public UserProfileSocialPlatform()
        {
        }

        public UserProfileSocialPlatform(int id, int userProfileId, int socialPlatformId, string socialProfileURI) : this()
        {
            Id = id;
            UserProfileId = userProfileId;
            SocialPlatformId = socialPlatformId;
            SocialProfileURI = socialProfileURI;
        }
    }
}
