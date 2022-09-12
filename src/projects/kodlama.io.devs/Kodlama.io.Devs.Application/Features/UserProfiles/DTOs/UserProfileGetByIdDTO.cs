namespace Kodlama.io.Devs.Application.Features.UserProfiles.DTOs
{
    public class UserProfileGetByIdDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GenderName { get; set; }
        public bool Status { get; set; }
    }
}
