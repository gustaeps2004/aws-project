using MFA.Domain.Extensions;

namespace MFA.Application.DTOs.cad
{
    public record CollaboratorDto
    {
        public string Name { get; init; }
        public string FederalDocument { get; init; }
        public DateTime Birthday { get; init; }
        public string Email { get; init; }


        public List<string> Validate()
        {
            var listErros = new List<string>();

            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
                listErros.Add("Name can't be null or empty.");

            if (!FederalDocument.ValidateCPF() && !FederalDocument.ValidateCNPJ())
                listErros.Add("Invalid federal document.");

            if (string.IsNullOrEmpty(Email) || string.IsNullOrWhiteSpace(Email) || !Email.ValidateEmail())
                listErros.Add("Invalid email.");

            return listErros;
        }
    }
}