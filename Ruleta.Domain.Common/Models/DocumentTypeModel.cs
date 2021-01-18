using System;
using System.ComponentModel.DataAnnotations;

namespace Ruleta.Domain.Common.Models
{
    public class DocumentTypeModel : BaseModel
    {
        #region Methods
        public DocumentTypeModel() { }
        public DocumentTypeModel( long id, string name, string code, DateTime creationDate, bool? state)
        {
            Id = id;
            Name = name;
            Code = code;
            State = (state == null) ? false : true;
            CreationDate = creationDate;
        }
        #endregion
    }
}
