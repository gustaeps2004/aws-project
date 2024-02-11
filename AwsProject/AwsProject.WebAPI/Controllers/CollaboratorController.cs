using AwsProject.Application.DTOs.cad;
using AwsProject.Application.Services.Collaborator;
using AwsProject.Domain.Models.cad;
using AwsProject.Domain.Validation;
using AwsProject.WebAPI.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AwsProject.WebAPI.Controllers
{
    [Authorize]
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
            catch (MFAException mfaEx) 
            {
                return BadRequest(mfaEx.Message);
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
            catch (MFAException mfaEx)
            {
                return BadRequest(mfaEx.Message);
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
            catch (MFAException mfaEx)
            {
                return BadRequest(mfaEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}