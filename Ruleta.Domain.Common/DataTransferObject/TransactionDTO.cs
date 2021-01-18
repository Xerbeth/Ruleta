using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;

namespace Ruleta.Domain.Common.DataTransferObject
{
    public class TransactionDTO<T>
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public TransactionDTO() 
        {
            Message = "Transacción realizada correctamente.";
            Status = Status.Success;
        }
    }
}
