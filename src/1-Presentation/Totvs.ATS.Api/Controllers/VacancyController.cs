using Microsoft.AspNetCore.Mvc;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Service.Interfaces;
using Totvs.ATS.Shared.Interfaces;

namespace Totvs.ATS.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VacancyController : BaseController
    {

        private readonly IVacancyService _vacancyService;

        public VacancyController(IBaseNotification baseNotification, IVacancyService vacancyService) : base(baseNotification)
        {
            _vacancyService = vacancyService;
        }
        /// <summary>
        /// Add vacancy
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(VacancyAddInput input)
        {
            var result = await _vacancyService.AddAsync(input);

            return CreatedOrBadRequest(result);
        }
        /// <summary>
        /// Update vacancy
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(VacancyUpdateInput input)
        {
            var result = await _vacancyService.UpdateAsync(input);

            return OKOrBadRequest(result);
        }
        /// <summary>
        /// List all vacancies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var result = await _vacancyService.GetAllAsync();

            return OKOrBadRequest(result);
        }
        
        /// <summary>
        /// List vacancy by id
        /// <paramref name="id"/>
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _vacancyService.GetByIdAsync(id);

            return OKOrBadRequest(result);
        }

        /// <summary>
        /// Delete vacancy by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _vacancyService.RemoveAsync(id);

            return Ok();
        }
    }
}
