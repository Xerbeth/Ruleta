using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ruleta.Domain.Common.DataTransferObject
{
    public class RouletteConfigurationDTO 
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public string Color { get; set; }
        public string Code { get; set; }
        public long RouletteId { get; set; }

        public RouletteConfigurationDTO() { }

        public RouletteConfigurationDTO(long id, string number, string color, string code, long rouletteId) 
        {
            Id = id;
            Number = number;
            Color = color;
            Code = code;
            RouletteId = rouletteId;
        }

    }
}
