using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Common.DataTransferObject
{
    public class ListRouletteDTO: ParametricDTO
    {
        public bool AllowBets { get; set; }

        public List<RouletteConfigurationDTO> Configuration { get; set; }

        public ListRouletteDTO() { }

        public ListRouletteDTO(long id, string name, string code, bool allowBets)
        {
            Id = id;
            Name = name;
            Code = code;
            AllowBets = allowBets;
        }


    }
}
