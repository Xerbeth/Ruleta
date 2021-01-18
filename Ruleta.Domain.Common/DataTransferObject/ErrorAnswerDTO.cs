using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Common.DataTransferObject
{
    public class ErrorAnswerDTO
    {
        public int State { get; set; }
        public List<ErrorDTO> Mistakes { get; set; }
        public ErrorAnswerDTO() { }
    }
}
