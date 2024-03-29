﻿using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using AutoMapper;
using AwsProject.Application.DTOs.AWS;
using AwsProject.Application.DTOs.cad;
using AwsProject.Domain.Enums;
using AwsProject.Domain.Extensions;
using AwsProject.Domain.Models.cad;
using AwsProject.Domain.Validation;
using AwsProject.Infra.Data.Repositories.Collaborator;
using AwsProject.Infra.Data.Repositories.CollaboratorFile;
using Microsoft.AspNetCore.Http;

namespace AwsProject.Application.Services.Collaborator
{
    public class CollaboratorApplicationService(
        ICollaboratorRepository<Domain.Models.cad.Collaborator> _collaboratorRepository,
        ICollaboratorFileRepository<CollaboratorFile> _collaboratorFileRepository,
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

        public void FormFileToMemoryStream(IFormFile file)
        {
            using var ms = new MemoryStream();
            file.CopyTo(ms);

            var fileExtension = Path.GetExtension(file.FileName);
            if (!fileExtension.Equals(".csv"))
                throw new AwsProjectException("Incorrect file extension, just .csv!");

            var code = Guid.NewGuid();
            var fileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{code}.{fileExtension.WithoutSpecialCharacters()}";
            UploadFileOnS3(ms, fileName);

            var pathFile = $"{Environment.GetEnvironmentVariable("AWS_BUCKET_COLLABORATOR")}/initial/{fileName}";
            Insert(code, pathFile);
        }

        private void UploadFileOnS3(MemoryStream ms, string fileName)
        {
            try
            {
                var credentials = new BasicAWSCredentials(AwsCredentials.AwsKey, AwsCredentials.AwsSecretKey);
                var config = new AmazonS3Config()
                {
                    RegionEndpoint = Amazon.RegionEndpoint.USEast1
                };

                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = ms,
                    Key = $"{Environment.GetEnvironmentVariable("AWS_BUCKET_COLLABORATOR")}/initial/{fileName}",
                    BucketName = Environment.GetEnvironmentVariable("AWS_BUCKET"),
                    CannedACL = S3CannedACL.NoACL
                };

                using var client = new AmazonS3Client(credentials, config);
                var transferUtility = new TransferUtility(client);
                transferUtility.Upload(uploadRequest);
            }
            catch (AmazonS3Exception s3Ex)
            {
                throw new AwsProjectException(s3Ex.Message);
            }
        }

        private void Insert(Guid code, string pathFile)
        {
            var collaboratorFile = new CollaboratorFile()
            {
                Code = code,
                PathFile = pathFile,
                SituationMessage = SituacaoCollaboratorFile.Imported.GetDescription(),
                Situation = SituacaoCollaboratorFile.Imported,
                InclusionDate = DateTime.Now,
                SituationDate = DateTime.Now
            };

            _collaboratorFileRepository.InsertCollaboratorFile(collaboratorFile);
        }
    }
}