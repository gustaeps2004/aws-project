using MFA.Application.DTOs.cad;
using MFA.Application.Services.Collaborator;
using MFA.Domain.Models.cad;
using MFA.Domain.Validation;
using MFA.WebAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace MFA.WebAPI.Controllers
{
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
                _collaboratorApplicationService.Insert(collaboratorDto);
                return Created();
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