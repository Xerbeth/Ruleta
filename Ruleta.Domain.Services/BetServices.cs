using Ruleta.Domain.BusinessLayer.Interfaces;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Services
{
    public class BetServices : IBetServices
    {
        private readonly IBetBL _betBl;
        public BetServices(IBetBL betBl)
        {
            _betBl = betBl;
        }
        public TransactionDTO<MessageDTO> CreateBet(CreateBetDTO createBet)
        {
            return _betBl.CreateBet(createBet);
        }
    }
}
