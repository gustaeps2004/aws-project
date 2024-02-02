namespace MFA.Domain.Validation
{
    public class MFAException(string errorMessage) : Exception(errorMessage)
    {
    }
}