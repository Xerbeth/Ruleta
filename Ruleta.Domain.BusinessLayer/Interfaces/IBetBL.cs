using Ruleta.Domain.Common.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.BusinessLayer.Interfaces
{
    public interface IBetBL
    {
        /// <summary>
        /// Method for creating the bet
        /// </summary>
        /// <param name="createBet"> Object for the creation of the bet </param>
        /// <returns> Creation object </returns>
        TransactionDTO<MessageDTO> CreateBet(CreateBetDTO createBet);
    }
}
