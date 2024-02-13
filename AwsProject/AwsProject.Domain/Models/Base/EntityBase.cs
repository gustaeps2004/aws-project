using AwsProject.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AwsProject.Domain.Models.Base
{
    public abstract class EntityBase<T>
    {
        [Key] public T Code { get; set; }
        public DateTime InclusionDate { get; set; }
        public DateTime SituationDate { get; set; }

        public abstract void Validate();
    }
}