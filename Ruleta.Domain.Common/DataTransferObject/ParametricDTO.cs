using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Common.DataTransferObject
{
    public class ParametricDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }

        public ParametricDTO() { }
    }
}
