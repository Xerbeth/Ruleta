using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Services.Interfaces;

namespace Ruleta.API.Controllers.RouletteConfiguration
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteConfigurationController : ControllerBase
    {
        private readonly IRouletteConfigurationServices _rouletteConfigurationServices;

        public RouletteConfigurationController(IRouletteConfigurationServices rouletteConfigurationServices)
        {
            _rouletteConfigurationServices = rouletteConfigurationServices;
        }

        /// <summary>
        /// Method to create roulette
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        [HttpGet("GetAllRouletteConfigurationByRoullete")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAllRouletteConfigurationByRoullete(long rouletteId)
        {
            try
            {
                return Ok(_rouletteConfigurationServices.GetAllRouletteConfigurationByRoulette(rouletteId));
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