using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Common.DataTransferObject
{
    public class CreateBetDTO
    {
        public long PlayerId { get; set; }
        public string BetType { get; set; }
        public string Value { get; set; }
        public float Price { get; set; }
        public long RouletteId { get; set; }

        public CreateBetDTO() 
        {
            PlayerId = 0;
            BetType = string.Empty;
            Value = string.Empty;
            Price = 0f;
            RouletteId = 0;
        }
    }
}
