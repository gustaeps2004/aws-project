using AwsProject.Application.DTOs.Authenticate;
using AwsProject.Domain.Validation;
using AwsProject.Infra.Data.Repositories.Collaborator;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AwsProject.Application.Services.Authentication
{
    public class AuthenticationApplicationServices(ICollaboratorRepository<Domain.Models.cad.Collaborator> _collaboratorRepository) : IAuthenticationApplicationServices
    {
        public TokenDto Access(string username, string password)
        {
            ValidateAccess(username, password);

            var collaborator = _collaboratorRepository.GetByEmailAndPassword(username, password) ?? throw new AwsProjectException("Invalid Access.");

            var token = GenerateToken(collaborator);
            return token;
        }

        private void ValidateAccess(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new AwsProjectException("Invalid Access.");
        }

        private TokenDto GenerateToken(Domain.Models.cad.Collaborator collaborator)
        {
            var claims = new[]
{
                new Claim(JwtRegisteredClaimNames.UniqueName, collaborator.Name),
                new Claim("email", collaborator.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("AUTH_LOGIN_SECRET")));

            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiracao = Environment.GetEnvironmentVariable("AUTH_LOGIN_EXPIRE_HOURS");
            var expiration = DateTime.UtcNow.AddHours(double.Parse(expiracao));

            var token = new JwtSecurityToken(
                issuer: Environment.GetEnvironmentVariable("AUTH_LOGIN_ISSUER"),
                audience: Environment.GetEnvironmentVariable("AUTH_LOGIN_AUDIENCE"),
                claims: claims,
                expires: expiration,
                signingCredentials: credenciais
            );

            return new TokenDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                FirstAccess = collaborator.FirstAccess
            };
        }
    }
}