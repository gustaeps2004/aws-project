using Amazon.Lambda.Core;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace AwsProject.Lambda.Collaborator.ValidateFile
{
    public class Function
    {
        public string Handler(string input, ILambdaContext context)
        {
            return input.ToUpper();
        }
    }
}
