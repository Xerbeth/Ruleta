using System;
using System.ComponentModel.DataAnnotations;

namespace Ruleta.Domain.Common.Models
{
   public class BaseModel
    {
        #region Properties
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public bool State { get; set; }
        public DateTime CreationDate { get; set; }
        #endregion

        #region Methods
        public BaseModel() { }
        #endregion
    }
}
