using Ruleta.Domain.Common.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.BusinessLayer.Interfaces
{
    public interface IBetTypeBL
    {
        /// <summary>
        /// Method to get all the records from the BetType table
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        TransactionDTO<List<BetTypeDTO>> GetAllBetType();
    }
}
