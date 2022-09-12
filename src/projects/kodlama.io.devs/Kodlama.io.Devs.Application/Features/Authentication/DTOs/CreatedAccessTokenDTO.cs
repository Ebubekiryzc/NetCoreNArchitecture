namespace Kodlama.io.Devs.Application.Features.Authentication.DTOs
{
    public class CreatedAccessTokenDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
