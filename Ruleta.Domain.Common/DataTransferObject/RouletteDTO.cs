using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Common.DataTransferObject
{
    public class RouletteDTO : ParametricDTO
    {
        public bool AllowBets { get; set; }

        public RouletteDTO() { }

        public RouletteDTO(long id, string name, string code, bool allowBets)
        {
            Id = id;
            Name = name;
            Code = code;
            AllowBets = allowBets;
        }
    }
}
