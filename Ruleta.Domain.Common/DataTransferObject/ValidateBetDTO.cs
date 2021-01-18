using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Common.DataTransferObject
{
    public class ValidateBetDTO
    {
        public long RouletteId { get; set; }
        public string Bet { get; set; }
    }
}
