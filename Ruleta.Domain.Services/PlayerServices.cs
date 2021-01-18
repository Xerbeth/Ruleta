using Ruleta.Domain.BusinessLayer.Interfaces;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Services.Interfaces;

namespace Ruleta.Domain.Services
{
    public class PlayerServices : IPlayerServices
    {
        private readonly IPlayerBL _playerBL;
        public PlayerServices(IPlayerBL playerBL)
        {
            _playerBL = playerBL;
        }

        public TransactionDTO<float> GetPlayerBalanceById(long playerId)
        {
            return _playerBL.GetPlayerBalanceById(playerId);
        }

        public TransactionDTO<PlayerDTO> GetPlayerById(long playerId)
        {
            return _playerBL.GetPlayerById(playerId);
        }

        public TransactionDTO<bool> ValidatePlayerBalance(ValidateBalancePlayerId validateBalancePlayerId)
        {
            return _playerBL.ValidatePlayerBalance(validateBalancePlayerId);
        }
    }
}
