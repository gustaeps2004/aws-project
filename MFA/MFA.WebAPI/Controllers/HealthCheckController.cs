using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MFA.WebAPI.Controllers
{
    [Route("api/health-check")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult HealthCheck()
        {
            try
            {
                return Ok();
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}