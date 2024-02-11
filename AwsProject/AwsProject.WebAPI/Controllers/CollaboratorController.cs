using AwsProject.Application.DTOs.AWS;
using AwsProject.Application.DTOs.AWS.S3;
using AwsProject.Application.DTOs.cad;
using AwsProject.Application.Services.Collaborator;
using AwsProject.Domain.Models.cad;
using AwsProject.Domain.Validation;
using AwsProject.WebAPI.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace AwsProject.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/collaborator")]
    [ApiController]
    public class CollaboratorController(ICollaboratorApplicationService _collaboratorApplicationService) : BaseController
    {
        [HttpGet]
        public ActionResult<IEnumerable<Collaborator>> All()
        {
            try
            {
                var collaborators = _collaboratorApplicationService.GetAll();
                return Ok(collaborators);
            }
            catch (AwsProjectException awsEx)
            {
                return BadRequest(awsEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{code:Guid}")]
        public ActionResult<Collaborator> ByCode(Guid code)
        {
            try
            {
                var collaborators = _collaboratorApplicationService.GetByCode(code);
                return Ok(collaborators);
            }
            catch (AwsProjectException awsEx)
            {
                return BadRequest(awsEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Insert(CollaboratorDto collaboratorDto)
        {
            try
            {
                var collaborator = _collaboratorApplicationService.Insert(collaboratorDto);

                return CreatedAtAction("Collaborator Created", collaborator);
            }
            catch (AwsProjectException awsEx)
            {
                return BadRequest(awsEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("upload-file")]
        public ActionResult ImportFile(IFormFile collaboratorFiles)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                collaboratorFiles.CopyTo(memoryStream);

                var fileExt = Path.GetExtension(collaboratorFiles.Name);
                var objName = $"{Guid.NewGuid()}.{fileExt}";

                var s3Object = new S3Object()
                {
                    BucketName = "aws-project-files",
                    InputStream = memoryStream,
                    Name = objName
                };

                var cred = new AwsCredentials()
                {
                    AwsKey = "AKIA2QDAFUJJE6JPZNOD",
                    AwsSecretKey = "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"
                };

                _collaboratorApplicationService.Upload(s3Object, cred);
                return Ok();
            }
            catch (AwsProjectException awsEx)
            {
                return BadRequest(awsEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}