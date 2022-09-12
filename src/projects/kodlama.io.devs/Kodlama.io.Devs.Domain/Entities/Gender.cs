using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Gender : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<UserProfile> UserProfiles { get; set; }

        public Gender()
        {

        }

        public Gender(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
