using MFA.Application.DTOs.Authenticate;

namespace MFA.Application.Services.Authentication
{
    public interface IAuthenticationApplicationServices
    {
        TokenDto Access(string username, string password);
    }
}
