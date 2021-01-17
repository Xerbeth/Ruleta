using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Common.DataTransferObject
{
    public class DocumentTypeDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }
        public DocumentTypeDTO() { }

        public DocumentTypeDTO(long id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }
    }
}
