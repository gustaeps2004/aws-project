using AwsProject.Domain.Models.Base;
using AwsProject.Domain.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwsProject.Domain.Models.cad
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

        public void InitialInsert()
        {
            Code = Guid.NewGuid();
            FirstAccess = true;
            Password = StringExtensions.GeneratePassword();
            Situation = Enums.Situation.Cadastrado;
            InclusionDate = DateTime.Now;
            SituationDate = DateTime.Now;
            FederalDocument = FederalDocument.OnlyNumbers();
        }

        public void Inactivating()
        {
            Situation = Enums.Situation.Desativado;
            SituationDate = DateTime.Now;
        }
    }
}