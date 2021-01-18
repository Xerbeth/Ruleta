using System;

namespace Ruleta.Domain.Common.Models
{
    public class BetModel
    {
        #region Properties
        public long Id { get; set; }
        public long PlayerId { get; set; }
        public long BetTypeId { get; set; }
        public long RouletteConfigurationId { get; set; }
        public float Value { get; set; }
        public float Prize { get; set; }
        public bool State { get; set; }
        public DateTime CreationDate { get; set; }
        #endregion

        #region Methods
        public BetModel() { }

        public BetModel(long id, long playerId, long betTypeId, long rouletteConfigurationId, float value, float prize, DateTime creationDate, bool? state)
        {
            Id = id;
            PlayerId = playerId;
            BetTypeId = betTypeId;
            RouletteConfigurationId = rouletteConfigurationId;
            Value = value;
            Prize = prize;
            State = (state == null) ? false : true;
            CreationDate = creationDate;
        }
        #endregion
    }
}
