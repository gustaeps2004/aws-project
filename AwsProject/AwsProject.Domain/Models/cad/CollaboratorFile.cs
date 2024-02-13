using AwsProject.Domain.Enums;
using AwsProject.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwsProject.Domain.Models.cad
{
    [Table("CollaboratorFile", Schema = "cad")]
    public class CollaboratorFile : EntityBase<Guid>
    {
        public string PathFile { get; set; }
        public string SituationMessage { get; set; }
        public SituacaoCollaboratorFile Situation { get; set; }

        public override void Validate()
        {
        }
    }
}
