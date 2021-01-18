using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Common.DataTransferObject
{
    public class MessageDTO
    {
        public string Message { get; set; }
        public bool Flag { get; set; }

        public MessageDTO() 
        {
            Message = string.Empty;
            Flag = false;
        }
    }
}
