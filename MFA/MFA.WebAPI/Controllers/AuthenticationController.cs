using MFA.Application.DTOs.Authenticate;
using MFA.Application.Services.Authentication;
using MFA.Domain.Validation;
using MFA.WebAPI.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MFA.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController(IAuthenticationApplicationServices _authenticateApplicationService) : BaseController
    {
        [HttpGet("access")]
        public ActionResult<TokenDto> Access([FromQuery] string username, string password)
        {
            try
            {
                var token = _authenticateApplicationService.Access(username, password);
                return Ok(token);
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