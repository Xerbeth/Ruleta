using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.BusinessLayer.Interfaces
{
    public interface IRouletteConfigurationBL
    {
        TransactionDTO<bool> CreateRouletteConfiguration(long rouletteId);
        TransactionDTO<List<RouletteConfigurationDTO>> GetAllRouletteConfigurationByRoulette(long rouletteId);
        TransactionDTO<List<RouletteConfigurationDTO>> GetAllRouletteConfiguration();
        TransactionDTO<bool> ValidateNumberByRouletteId(ValidateBetDTO validateBet);
        TransactionDTO<bool> ValidateColorByRouletteId(ValidateBetDTO validateBet);
    }
}
