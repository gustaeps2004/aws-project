using System.ComponentModel;

namespace AwsProject.Domain.Enums
{
    public enum SituacaoCollaboratorFile
    {
        [Description("Imported File")] Imported = 0,
        [Description("Validated File")] Validated = 1,
        [Description("File Completed")] Concluded = 2,
        [Description("File Error")] Error = 3
    }
}