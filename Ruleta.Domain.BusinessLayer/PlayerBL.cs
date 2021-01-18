using Ruleta.Domain.BusinessLayer.Interfaces;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.DAL.Repository.Interfaces;
using System;

namespace Ruleta.Domain.BusinessLayer
{
    public class PlayerBL: IPlayerBL
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerBL(IPlayerRepository playerRepository) 
        {
            _playerRepository = playerRepository;
        }

        public TransactionDTO<float> GetPlayerBalanceById(long playerId)
        {
            TransactionDTO<float> transaction = new TransactionDTO<float>();
            transaction.Data = 0f;
            try
            {
                var getPlayerBalanceById = _playerRepository.GetPlayerBalanceById(playerId);
                transaction.Data = getPlayerBalanceById;
            }
            catch (ArgumentException ex)
            {
                transaction.Status = Common.Status.Failure;
                transaction.Message = ex.Message;
            }

            return transaction;
        }

        public TransactionDTO<PlayerDTO> GetPlayerById(long playerId)
        {
            TransactionDTO<PlayerDTO> transaction = new TransactionDTO<PlayerDTO>();
            transaction.Data = new PlayerDTO();
            try
            {
                var getPlayerById = _playerRepository.GetPlayerById(playerId);
                if (getPlayerById == null || getPlayerById.Id == 0)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = "No fue posible obtener resultados por el identificador de jugador "+ playerId;

                    return transaction;
                }
                transaction.Data.Id = getPlayerById.Id;
                transaction.Data.FirstName = getPlayerById.FirstName;
                transaction.Data.Surname = getPlayerById.Surname;
                transaction.Data.Balance = getPlayerById.Balance;
            }
            catch (ArgumentException ex)
            {
                transaction.Status = Common.Status.Failure;
                transaction.Message = ex.Message;
            }

            return transaction;
        }
    }
}
