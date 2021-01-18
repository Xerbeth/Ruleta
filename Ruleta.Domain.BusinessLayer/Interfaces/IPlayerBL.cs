using Ruleta.Domain.Common.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.BusinessLayer.Interfaces
{
    public interface IPlayerBL
    {
        TransactionDTO<PlayerDTO> GetPlayerById(long playerId);
        TransactionDTO<float> GetPlayerBalanceById(long playerId);
        TransactionDTO<bool> ValidatePlayerBalance(ValidateBalancePlayerId validateBalancePlayerId);
    }
}
