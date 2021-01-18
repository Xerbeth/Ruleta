using Ruleta.Domain.Common.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Services.Interfaces
{
    public interface IBetTypeServices
    {
        /// <summary>
        /// Method to get all the records from the BetType table
        /// </summary>
        /// <returns> object with the transaction information </returns>
        TransactionDTO<List<BetTypeDTO>> GetAllBetType();
        /// <summary>
        /// method to get the type of bet by the code of the bet
        /// </summary>
        /// <param name="code"> bet code </param>
        /// <returns> Object with the transaction information  </returns>
        TransactionDTO<BetTypeDTO> GetBetTypeByCode(string code);
    }
}
