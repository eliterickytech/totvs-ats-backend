﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Totvs.ATS.Shared.Interfaces;
using Totvs.ATS.Service.Result;

namespace Totvs.ATS.Api
{
    /// <summary>
    /// BaseController
    /// </summary>
    public class BaseController : ControllerBase
    {
        private readonly IBaseNotification _baseNotification;
        private readonly ILogger<BaseController> _logger;
        /// <summary>
        /// Problema Details
        /// </summary>
        public ProblemDetailsFactory? ProblemDetails => HttpContext?.RequestServices?.GetRequiredService<ProblemDetailsFactory>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseNotification"></param>
        public BaseController(IBaseNotification baseNotification)
        {
            _baseNotification = baseNotification;
        }

        /// <summary>
        /// Return customized to API
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected IActionResult OKOrBadRequest(object? result)
        {
            if (_baseNotification.IsValid)
            {
                var resultModel = new Result(
                    StatusCode: HttpStatusCode.OK,
                    Data: result);

                return Ok( resultModel);
            }

            return BadRequestBase();
        }
        /// <summary>
        /// Return customized to API
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected IActionResult OKOrBadRequest(object result, object pagination)
        {
            if (_baseNotification.IsValid)
            {
                var resultModel = new ResultPagination(
                    StatusCode: HttpStatusCode.OK,
                    Data: result,
                    Pagination: pagination);

                return Ok(resultModel);
            }

            return BadRequestBase();
        }
        /// <summary>
        /// Return customized to API
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected IActionResult CreatedOrBadRequest(object result)
        {
            if (_baseNotification.IsValid) 
            {
                var resultModel = new Result(
                    StatusCode: HttpStatusCode.Created,
                    Data: result);
                return Created(string.Empty, resultModel);
            }
            

            return BadRequestBase();
        }

        /// <summary>
        /// Return customized to API
        /// </summary>
        /// <returns></returns>
        protected IActionResult BadRequestBase()
        {
            var problemDetails = ProblemDetails?.CreateProblemDetails(HttpContext, (int)HttpStatusCode.BadRequest, "Bad request");
            var notifications = _baseNotification.Notifications.Select(notification => new { name = notification.Key, reason = notification.Message });

            problemDetails?.Extensions.Add("invalid-params", notifications);

            return BadRequest(problemDetails);
        }

    }
}


