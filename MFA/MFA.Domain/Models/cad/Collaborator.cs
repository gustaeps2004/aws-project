using MFA.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFA.Domain.Models.cad
{
    [Table("Collaborator", Schema = "cad")]
    public class Collaborator : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string FederalDocument { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool FirstAccess { get; set; }
        
    }
}