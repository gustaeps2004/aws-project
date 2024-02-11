using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using AutoMapper;
using AwsProject.Application.DTOs.AWS;
using AwsProject.Application.DTOs.AWS.S3;
using AwsProject.Application.DTOs.cad;
using AwsProject.Domain.Extensions;
using AwsProject.Domain.Validation;
using AwsProject.Infra.Data.Repositories.Collaborator;

namespace AwsProject.Application.Services.Collaborator
{
    public class CollaboratorApplicationService(
        ICollaboratorRepository<Domain.Models.cad.Collaborator> _collaboratorRepository,
        IMapper _mapper) : ICollaboratorApplicationService
    {
        public IEnumerable<Domain.Models.cad.Collaborator> GetAll()
        {
            // apply filter here, when front is done
            return _collaboratorRepository.GetAll();
        }

        public Domain.Models.cad.Collaborator GetByCode(Guid code)
        {
            var collaborator = _collaboratorRepository.GetByCode(code) ?? throw new AwsProjectException("Collaborator not located.");
            return collaborator;
        }

        public Domain.Models.cad.Collaborator Insert(CollaboratorDto collaboratorDto)
        {
            var errorList = collaboratorDto.Validate();
            
            if (errorList.Any())
                throw new AwsProjectException(string.Join(";", errorList));

            var isExist = _collaboratorRepository.GetByEmailAndFederalDocument(collaboratorDto.Email, collaboratorDto.FederalDocument.OnlyNumbers());

            if (isExist is not null)
                throw new AwsProjectException("Collaborator already exist.");

            var collaborator = _mapper.Map<Domain.Models.cad.Collaborator>(collaboratorDto);
            collaborator.InitialInsert();

            _collaboratorRepository.Insert(collaborator);

            return collaborator;
        }

        public S3Response Upload(S3Object s3Object, AwsCredentials awsCredentials)
        {
            var credentials = new BasicAWSCredentials(awsCredentials.AwsKey, awsCredentials.AwsSecretKey);

            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            };

            var response = new S3Response();

            try
            {
                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = s3Object.InputStream,
                    Key = s3Object.Name,
                    BucketName = s3Object.BucketName,
                    CannedACL = S3CannedACL.NoACL
                };

                using var client = new AmazonS3Client(credentials, config);

                var transferUtility = new TransferUtility(client);

                transferUtility.Upload(uploadRequest);

                response.StatusCode = 200;
                response.Message = $"{s3Object.Name} has been uploaded succesfully.";

            }
            catch (AmazonS3Exception s3Ex)
            {
                response.StatusCode = (int)s3Ex.StatusCode;
                response.Message = s3Ex.Message;
            }
            
            return response;
        }
    }
}