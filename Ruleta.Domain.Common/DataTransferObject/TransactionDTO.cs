using System;
using System.Collections.Generic;
using System.Data;
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
            Status = Status.Failure;
        }
    }
}
