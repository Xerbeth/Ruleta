using System;

namespace Ruleta.Domain.Common.Models
{
    public class RouletteModel : BaseModel
    {
        #region Properties
        public bool AllowBets { get; set; }
        #endregion
        #region Methods
        public RouletteModel() { }

        public RouletteModel(long id, string name, string code, DateTime creationDate, bool? state)
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
