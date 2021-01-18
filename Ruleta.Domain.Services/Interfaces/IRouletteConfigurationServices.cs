using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Services.Interfaces
{
    public interface IRouletteConfigurationServices
    {
        TransactionDTO<List<RouletteConfigurationModel>> GetAllRouletteConfigurationByRoullete(long rouletteId);

        TransactionDTO<bool> CreateRouletteConfiguration(long rouletteId);
    }
}
