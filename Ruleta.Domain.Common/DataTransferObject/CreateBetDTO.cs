using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ruleta.Domain.Common.DataTransferObject
{
    public class CreateBetDTO
    {
        public long PlayerId { get; set; }
        public string BetType { get; set; }
        public long BetTypeId { get; set; }
        public string Bet { get; set; }
        public float Prize { get; set; }
        public long RouletteId { get; set; }        

        public CreateBetDTO() 
        {
            PlayerId = 0;
            BetTypeId = 0;
            BetType = string.Empty;
            Bet = string.Empty;
            Prize = 0f;
            RouletteId = 0;
        }
    }
}
