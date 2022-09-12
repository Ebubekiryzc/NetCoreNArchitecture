namespace Kodlama.io.Devs.Application.Features.Authentication.Constants
{
    public static class ExceptionMessages
    {
        public const string AuthenticationUserEmailExist = "A user with the given email already exists.";
        public const string AuthenticationUserEmailNotFound = "No user found matching these email address.";
        public const string AuthenticationCredentialsNotMatch = "The provided credentials do not match any user.";
    }
}
