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
        /// Method to create roulette
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        public TransactionDTO<long> CreateRoulette()
        {
            return _rouletteBL.CreateRoulette();
        }
    }
}
