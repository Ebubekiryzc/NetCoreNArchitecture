using Core.Security.Dtos;

namespace Kodlama.io.Devs.Application.Features.Authentication.DTOs
{
    public class RegisterUserDTO : UserForRegisterDto
    {
        public int GenderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
