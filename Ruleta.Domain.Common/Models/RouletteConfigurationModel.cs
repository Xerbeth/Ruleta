using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Text;

namespace Ruleta.Domain.Common.Models
{
    public class RouletteConfigurationModel
    {
        #region Properties
        public long Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public long RouletteId { get; set; }
        public bool State { get; set; }
        public DateTime CreationDate { get; set; }
        #endregion

        #region Methods
        public RouletteConfigurationModel() { }
        public RouletteConfigurationModel(long id, string number, string color, string code, long rouletteId, DateTime creationDate, bool? state)
        {
            Id = id;
            Number = number;
            Color = color;
            Code = code;
            RouletteId = rouletteId;
            State = (state == null) ? false : true;
            CreationDate = creationDate;
        }
        #endregion
    }
}