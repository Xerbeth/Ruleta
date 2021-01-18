using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Common.DataTransferObject
{
    public class DocumentTypeDTO : ParametricDTO
    {        
        public DocumentTypeDTO() { }

        public DocumentTypeDTO(long id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }
    }
}
