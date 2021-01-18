using Ruleta.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.DAL.Repository.Interfaces
{
    public interface IRouletteConfigurationRepository
    {
        /// <summary>
        /// Method to create the roulette configuration
        /// </summary>
        /// <param name="rouletteId"> roulette identifier </param>
        void CreateRouletteConfiguration(long rouletteId);
        /// <summary>
        /// Method to consult the records by roulette identifier
        /// </summary>
        /// <param name="rouletteId"> Roulette identifier </param>
        /// <returns> Object with the transaction information </returns>
        public List<RouletteConfigurationModel> GetAllRouletteConfigurationByRoulette(long rouletteId);
        /// <summary>
        /// Method to consult the all records
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        public List<RouletteConfigurationModel> GetAllRouletteConfiguration();
    }
}
