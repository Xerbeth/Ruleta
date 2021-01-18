using Ruleta.Domain.BusinessLayer.Interfaces;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Common.Models;
using Ruleta.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Services
{
    public class RouletteConfigurationServices : IRouletteConfigurationServices
    {
        private readonly IRouletteConfigurationBL _rouletteConfigurationBL;

        public RouletteConfigurationServices(IRouletteConfigurationBL rouletteConfigurationBL)
        {
            _rouletteConfigurationBL = rouletteConfigurationBL;
        }

        public TransactionDTO<bool> CreateRouletteConfiguration(long rouletteId)
        {
            return _rouletteConfigurationBL.CreateRouletteConfiguration(rouletteId);
        }

        public TransactionDTO<List<RouletteConfigurationModel>> GetAllRouletteConfigurationByRoullete(long rouletteId)
        {
            return _rouletteConfigurationBL.GetAllRouletteConfigurationByRoullete(rouletteId);
        }
    }
}
