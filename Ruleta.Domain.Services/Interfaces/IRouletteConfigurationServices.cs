using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Services.Interfaces
{
    public interface IRouletteConfigurationServices
    {
        TransactionDTO<List<RouletteConfigurationDTO>> GetAllRouletteConfigurationByRoulette(long rouletteId);
        TransactionDTO<List<RouletteConfigurationDTO>> GetAllRouletteConfiguration();
        TransactionDTO<bool> CreateRouletteConfiguration(long rouletteId);
        public TransactionDTO<bool> ValidateColorByRouletteId(ValidateBetDTO validateBet);
        public TransactionDTO<bool> ValidateNumberByRouletteId(ValidateBetDTO validateBet);
    }
}
