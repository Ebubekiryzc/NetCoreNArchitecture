using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class SocialPlatform : Entity
    {
        public string Name { get; set; }
        public string Domain { get; set; }

        public virtual ICollection<UserProfileSocialPlatform> UserProfileSocialPlatforms { get; set; }

        public SocialPlatform()
        {
        }

        public SocialPlatform(int id, string name, string domain) : this()
        {
            Id = id;
            Name = name;
            Domain = domain;
        }
    }
}
