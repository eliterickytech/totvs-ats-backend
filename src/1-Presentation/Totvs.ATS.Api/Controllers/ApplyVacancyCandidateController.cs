using Microsoft.AspNetCore.Mvc;
using Totvs.ATS.Domain;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Service.Interfaces;
using Totvs.ATS.Shared.Interfaces;

namespace Totvs.ATS.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ApplyVacancyCandidateController : BaseController
    {

        private readonly IApplyVacancyCandidateService _applyVacancyCandidateService;

        public ApplyVacancyCandidateController(IBaseNotification baseNotification, IApplyVacancyCandidateService applyVacancyCandidateService) : base(baseNotification)
        {
            _applyVacancyCandidateService = applyVacancyCandidateService;
        }
        /// <summary>
        /// Add vacancy with candidate
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(ApplyVacancyCadidateInput input)
        {
            return CreatedOrBadRequest(await _applyVacancyCandidateService.AddAsync(input));
        }


        /// <summary>
        /// Delete vacancy with candidate by id
        /// </summary>
        /// <param name="candidateId"></param>
        /// <param name="vacancyId"></param>
        /// <returns></returns>
        [HttpDelete("{candidateId}/{vacancyId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid candidateId, Guid vacancyId)
        {
            return Ok(await _applyVacancyCandidateService.RemoveAsync(candidateId, vacancyId));
        }
    }
}
