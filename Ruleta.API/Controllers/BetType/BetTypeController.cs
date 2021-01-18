using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Services.Interfaces;

namespace Ruleta.API.Controllers.BetType
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetTypeController : ControllerBase
    {
        readonly IBetTypeServices _betTypeServices;
        public BetTypeController(IBetTypeServices betTypeServices)
        {
            _betTypeServices = betTypeServices;
        }

        /// <summary>
        /// Method to get all the records from the BetType table
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        [HttpGet("GetAllBetType")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAllBetType()
        {
            try
            {
                return Ok(_betTypeServices.GetAllBetType());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorAnswerDTO()
                {
                    State = StatusCodes.Status400BadRequest,
                    Mistakes = new List<ErrorDTO>(new[]
                    {
                         new ErrorDTO()
                         {
                             Code = "",
                             Description = ex.Message
                         }
                     })
                });
            }
        }
    }
}