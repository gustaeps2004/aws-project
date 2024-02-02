using MFA.WebAPI.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MFA.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : BaseController
    {

    }
}