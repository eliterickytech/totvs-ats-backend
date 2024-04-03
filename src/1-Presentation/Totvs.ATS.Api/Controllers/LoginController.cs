using Microsoft.AspNetCore.Mvc;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Service.Interfaces;
using Totvs.ATS.Service.Results;
using Totvs.ATS.Shared.Interfaces;

namespace Totvs.ATS.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {

        private readonly ICandidateService _candidateService;
        private readonly ILoginService _loginService;

        public LoginController(IBaseNotification baseNotification, ICandidateService candidateService, ILoginService loginService) : base(baseNotification)
        {
            _candidateService = candidateService;
            _loginService = loginService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CandidateResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(LoginInput input)
        {
            return CreatedOrBadRequest(await _loginService.AuthenticationAsync(input));
        }
    }
}
