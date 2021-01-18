using Ruleta.Domain.Common.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Services.Interfaces
{
    public interface IRouletteServices
    {
        /// <summary>
        /// Method to create roulette
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        TransactionDTO<long> CreateRoulette();        
    }
}
