using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Ruleta.Domain.Common.DataTransferObject
{
    public class BetTypeDTO : ParametricDTO
    {
        public string Description { get; set; }
        public float Pay { get; set; }

        public BetTypeDTO() { }

        public BetTypeDTO(long id, string name, string code, string description, float pay) 
        {
            Id = id;
            Name = name;
            Code = code;
            Description = description;
            Pay = pay;
        }
    }
}
