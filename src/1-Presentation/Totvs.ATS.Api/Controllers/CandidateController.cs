using Microsoft.AspNetCore.Mvc;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Service.Interfaces;
using Totvs.ATS.Shared.Interfaces;

namespace Totvs.ATS.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CandidateController : BaseController
    {

        private readonly ICandidateService _candidateService;

        public CandidateController(IBaseNotification baseNotification, ICandidateService candidateService) : base(baseNotification)
        {
            _candidateService = candidateService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CandidateAddInput input)
        {
            return CreatedOrBadRequest(await _candidateService.AddAsync(input));
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(CandidateUpdateInput input)
        {
            return OKOrBadRequest(await _candidateService.UpdateAsync(input));
        }

        [HttpGet]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return OKOrBadRequest(await _candidateService.GetAllAsync());
        }
        /// <summary>
        /// List candidates by id
        /// <paramref name="id"/>
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            return OKOrBadRequest(await _candidateService.GetByIdAsync(id));
        }

        /// <summary>
        /// Delete candidate by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _candidateService.RemoveAsync(id));
        }
    }
}
