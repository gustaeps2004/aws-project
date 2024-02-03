using MFA.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MFA.Domain.Models.Base
{
    public abstract class EntityBase<T>
    {
        [Key] public T Code { get; set; }
        public Situation Situation { get; set; }
        public DateTime InclusionDate { get; set; }
        public DateTime SituationDate { get; set; }
    }
}