using Core.Security.Entities;
using Core.Security.Enums;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class UserProfile : User
    {
        public int GenderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastActiveness { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual ICollection<UserProfileSocialPlatform> UserProfileSocialPlatforms { get; set; }

        public UserProfile()
        {
        }

        public UserProfile(int id, string email, byte[] passwordSalt, byte[] passwordHash,
                           bool status, AuthenticatorType authenticatorType,
                           int genderId, string firstName, string lastName, DateTime dateOfBirth) : this()
        {
            Id = id;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            Status = status;
            AuthenticatorType = authenticatorType;
            GenderId = genderId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            CreatedAt = DateTime.Now;
        }
    }
}
