using System;

namespace Ruleta.Domain.Common.Models
{
    public class BetModel
    {
        #region Properties
        public long Id { get; set; }
        public long PlayerId { get; set; }
        public long BetTypeId { get; set; }
        public long RouletteId { get; set; }
        public string Bet { get; set; }
        public float Prize { get; set; }
        public float Profits { get; set; }
        public bool State { get; set; }
        public DateTime CreationDate { get; set; }
        #endregion

        #region Methods
        public BetModel() { }

        public BetModel(long id, long playerId, long betTypeId, long rouletteId, string bet, float prize, float profits, DateTime creationDate, bool? state)
        {
            Id = id;
            PlayerId = playerId;
            BetTypeId = betTypeId;
            RouletteId = rouletteId;
            Bet = bet;
            Prize = prize;
            Profits = profits;
            State = (state == null) ? false : true;
            CreationDate = creationDate;
        }
        #endregion
    }
}
