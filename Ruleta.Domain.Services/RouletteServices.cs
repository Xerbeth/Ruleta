using Ruleta.Domain.BusinessLayer.Interfaces;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Services
{
    public class RouletteServices : IRouletteServices
    {
        private readonly IRouletteBL _rouletteBL;

        public RouletteServices(IRouletteBL rouletteBL) 
        {
            _rouletteBL = rouletteBL;
        }

        /// <summary>
        /// Method to get all roulette records
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        public TransactionDTO<List<RouletteDTO>> GetAllRoulette()
        {
            return _rouletteBL.GetAllRoulette();
        }

        /// <summary>
        /// Method to create roulette
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        public TransactionDTO<long> CreateRoulette()
        {
            return _rouletteBL.CreateRoulette();
        }

        /// <summary>
        /// Method to consult a roulette by identifier
        /// </summary>
        /// <param name="rouletteId"> roulette identifier </param>
        /// <returns> Object with the transaction information </returns>
        public TransactionDTO<RouletteDTO> GetRouletteById(long rouletteId)
        {
            return _rouletteBL.GetRouletteById(rouletteId);
        }

        /// <summary>
        /// Method to open roulette
        /// </summary>
        /// <param name="rouletteId"> roulette identifier </param>
        /// <returns> Object with the transaction information </returns>
        public TransactionDTO<bool> RouletteOpening(long rouletteId)
        {
            return _rouletteBL.RouletteOpening(rouletteId);
        }
        /// <summary>
        /// Method to validate the state of the roulette wheel to place bets
        /// </summary>
        /// <param name="rouletteId"> roulette identifier </param>
        /// <returns> Object with the transaction information </returns>
        public TransactionDTO<bool> ValidateRouletteStatus(long rouletteId)
        {
            return _rouletteBL.ValidateRouletteStatus(rouletteId);
        }
    }
}
