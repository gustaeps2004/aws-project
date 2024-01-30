using MFA.Domain.Enums;

namespace MFA.Domain.Models.Base
{
    public abstract class EntityBase<T>
    {
        public T Code { get; set; }
        public Situation Situation { get; set; }
        public DateTime InclusionDate { get; set; }
        public DateTime SituationDate { get; set; }
    }
}