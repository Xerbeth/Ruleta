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

        TransactionDTO<List<RouletteConfigurationModel>> GetAllRouletteConfigurationByRoullete(long rouletteId);
    }
}
