namespace AwsProject.Application.DTOs.AWS
{
    public class AwsCredentials
    {
        public static string AwsKey = Environment.GetEnvironmentVariable("AWS_CREDENTIALS_ACCESS_KEY")!;
        public static string AwsSecretKey = Environment.GetEnvironmentVariable("AWS_CREDENTIALS_SECRET_KEY")!;
    }
}