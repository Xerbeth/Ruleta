using Ruleta.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.DAL.Repository.Interfaces
{
    public interface IPlayerRepository
    {
        PlayerModel GetPlayerById(long playerId);
        float GetPlayerBalanceById(long playerId);
    }
}
