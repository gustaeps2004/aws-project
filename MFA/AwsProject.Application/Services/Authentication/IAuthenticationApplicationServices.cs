using AwsProject.Application.DTOs.Authenticate;

namespace AwsProject.Application.Services.Authentication
{
    public interface IAuthenticationApplicationServices
    {
        TokenDto Access(string username, string password);
    }
}
