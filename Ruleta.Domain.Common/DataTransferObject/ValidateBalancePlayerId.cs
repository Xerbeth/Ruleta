using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Common.DataTransferObject
{
    public class ValidateBalancePlayerId
    {
        public long PlayerId { get; set; }
        public float Price { get; set; }

        public ValidateBalancePlayerId() { }

        public ValidateBalancePlayerId(long playerId, float price)
        {
            PlayerId = playerId;
            Price = price;
        }
    }
}
