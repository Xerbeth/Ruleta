using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.DAL.Repository.Interfaces
{
    public interface IRouletteRepository
    {
        List<RouletteModel> GetAllRoulette();
        long CreateRoulette(RouletteModel rouletteModel);
        RouletteModel GetRouletteById(long rouletteId);
        bool RouletteOpening(long rouletteId);        
    }
}
