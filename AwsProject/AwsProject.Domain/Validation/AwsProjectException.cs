namespace AwsProject.Domain.Validation
{
    public class AwsProjectException(string errorMessage) : Exception(errorMessage)
    {
    }
}