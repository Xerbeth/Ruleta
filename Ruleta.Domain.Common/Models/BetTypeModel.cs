using System;

namespace Ruleta.Domain.Common.Models
{
    public class BetTypeModel : BaseModel
    {
        #region Properties
        public string Description { get; set; }
        public float Pay { get; set; }
        #endregion

        #region Methods
        public BetTypeModel(){}

        public BetTypeModel(long id, string name, string code, string description, float pay, DateTime creationDate, bool? state) 
        {
            Id = id;
            Name = name;
            Code = code;
            Description = description;
            Pay = pay;
            State = (state==null)? false: true;
            CreationDate = creationDate;
        }
        #endregion
    }
}
