using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Common.DataTransferObject
{
    public class ErrorDTO
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public ErrorDTO() { }
    }
}
