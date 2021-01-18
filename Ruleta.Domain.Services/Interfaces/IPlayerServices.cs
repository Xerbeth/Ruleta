using Ruleta.Domain.Common.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Services.Interfaces
{
    public interface IPlayerServices
    {
        TransactionDTO<PlayerDTO> GetPlayerById(long playerId);
        TransactionDTO<float> GetPlayerBalanceById(long playerId);
    }
}
