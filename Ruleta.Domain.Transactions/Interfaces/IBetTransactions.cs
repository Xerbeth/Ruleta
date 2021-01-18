using Ruleta.Domain.Common.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Transactions.Interfaces
{
    public interface IBetTransactions
    {
        string CreateBet(CreateBetDTO createBet);
    }
}
