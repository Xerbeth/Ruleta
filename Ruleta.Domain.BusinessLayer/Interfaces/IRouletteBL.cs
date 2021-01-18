using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.BusinessLayer.Interfaces
{
    public interface IRouletteBL
    {
        /// <summary>
        /// Method to get all roulette records
        /// </summary>
        /// <returns> List of records </returns>
        TransactionDTO<List<RouletteModel>> GetAllRoulette();
        /// <summary>
        /// Method to create roulette
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        TransactionDTO<long> CreateRoulette();
    }
}
