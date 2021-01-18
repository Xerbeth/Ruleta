using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Transactions.Interfaces;

namespace Ruleta.API.Controllers.Bet
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {

        private readonly IBetTransactions _betTransactions;

        public BetController(IBetTransactions betTransactions)
        {
            _betTransactions = betTransactions;
        }

        /// <summary>
        /// Method to creare bets. POINT 4.
        /// betType => NMR ó CLR.
        /// Value => number ó Color. 
        /// Price => $$$.
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        [HttpPost("CreateBet")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult CreateBet(CreateBetDTO createBet)
        {
            try
            {
                return Ok(_betTransactions.CreateBet(createBet));
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