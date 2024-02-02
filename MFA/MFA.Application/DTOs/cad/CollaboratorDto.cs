using MFA.Domain.Enums;

namespace MFA.Application.DTOs.cad
{
    public record CollaboratorDto
    {
        public string Name { get; init; }
        public string FederalDocument { get; init; }
        public DateTime Birthday { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public bool FirstAccess { get; init; }
        public Situation Situation { get; init; }
    }
}