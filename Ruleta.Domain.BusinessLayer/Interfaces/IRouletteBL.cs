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
        /// <returns> Object with the transaction information </returns>
        TransactionDTO<List<RouletteDTO>> GetAllRoulette();
        /// <summary>
        /// Method to create roulette
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        TransactionDTO<long> CreateRoulette();
        /// <summary>
        /// Method to consult a roulette by identifier
        /// </summary>
        /// <param name="rouletteId"> roulette identifier </param>
        /// <returns> Object with the transaction information </returns>
        TransactionDTO<RouletteDTO> GetRouletteById(string rouletteId);
        /// <summary>
        /// Method to open roulette
        /// </summary>
        /// <param name="rouletteId"> roulette identifier </param>
        /// <returns> Object with the transaction information </returns>
        TransactionDTO<bool> RouletteOpening(string rouletteId);
    }
}
