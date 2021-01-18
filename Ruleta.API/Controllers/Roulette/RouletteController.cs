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
        [HttpGet("GetAllRoulette")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAllRoulette()
        {
            try
            {
                return Ok(_routelleServices.GetAllRoulette());
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

        /// <summary>
        /// Method to create roulette. POINT 1
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        [HttpPut("CreateRoulette")]
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

        /// <summary>
        /// Method to obtain the information of a roulette by id
        /// </summary>
        /// <param name="rouletteId"> Roulette identifier </param>
        /// <returns> Object with the transaction information </returns>
        [HttpGet("GetRouletteById")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetRouletteById(string rouletteId)
        {
            try
            {
                return Ok(_routelleServices.GetRouletteById(rouletteId));
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

        /// <summary>
        /// Method to open roulette. POINT 2
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        [HttpPost("RouletteOpening")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult RouletteOpening(string rouletteId)
        {
            try
            {
                return Ok(_routelleServices.RouletteOpening(rouletteId));
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

        /// <summary>
        /// service to get the rules created with the bet status. POINT 5
        /// </summary>
        /// <returns> list of roulettes created with their status </returns>
        [HttpGet("GetAllRoulettes")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult CombineRouletteAndConfiguration()
        {
            try
            {
                return Ok(_rouletteTransactions.GetRouletteConfiguration());
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