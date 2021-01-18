using Ruleta.Domain.Common.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Services.Interfaces
{
    public interface IBetServices
    {
        TransactionDTO<MessageDTO> CreateBet(CreateBetDTO createBet);
    }
}
