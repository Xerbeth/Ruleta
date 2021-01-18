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
    }
}
