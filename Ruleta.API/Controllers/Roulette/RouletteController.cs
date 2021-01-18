using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Services.Interfaces;
using Ruleta.Domain.Transactions.Interfaces;

namespace Ruleta.API.Controllers.Roulette
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteServices _routelleServices;
        private readonly IRouletteTransactions _rouletteTransactions;

        public RouletteController(IRouletteServices routelleServices, IRouletteTransactions rouletteTransactions)
        {
            _routelleServices = routelleServices;
            _rouletteTransactions = rouletteTransactions;
        }

        /// <summary>
        /// Method to create roulette
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        [HttpGet("CreateRoulette")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult CreateRoulette()
        {
            try
            {
                return Ok(_routelleServices.CreateRoulette());
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