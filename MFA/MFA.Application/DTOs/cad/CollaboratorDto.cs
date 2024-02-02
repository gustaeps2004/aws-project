using MFA.Domain.Enums;

namespace MFA.Application.DTOs.cad
{
    public record class CollaboratorDto
    {
        public string Name { get; set; }
        public string FederalDocument { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool FirstAccess { get; set; }
        public Situation Situation { get; set; }
    }
}