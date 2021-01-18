using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Services.Interfaces;
using Ruleta.Domain.Transactions.Interfaces;
using System;
using Ruleta.Domain.Common.Enum;

namespace Ruleta.Domain.Transactions
{
    public class BetTransactions : IBetTransactions
    {
        private readonly IPlayerServices _playerServices;
        private readonly IRouletteConfigurationServices _rouletteConfigurationServices;
        private readonly IRouletteServices _rouletteServices;
        private readonly IBetTypeServices _betTypeServices;
        private readonly IBetServices _betServices;
        public BetTransactions(IPlayerServices playerServices,
                               IRouletteConfigurationServices rouletteConfigurationServices,
                               IRouletteServices rouletteServices,
                               IBetTypeServices betTypeServices,
                               IBetServices betServices)
        {
            _playerServices = playerServices;
            _rouletteConfigurationServices = rouletteConfigurationServices;
            _rouletteServices = rouletteServices;
            _betTypeServices = betTypeServices;
            _betServices = betServices;
        }

        public TransactionDTO<string> CreateBet(CreateBetDTO createBet)
        {
            TransactionDTO<string> transaction = new TransactionDTO<string>();
            try
            {                
                var getPlayerById = _playerServices.GetPlayerById(createBet.PlayerId);
                if (getPlayerById.Data == null || getPlayerById.Data.Id == 0)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = getPlayerById.Message;
                    return transaction;
                }
                ValidateBalancePlayerId validateBalancePlayerId = new ValidateBalancePlayerId(createBet.PlayerId, createBet.Prize);
                var validatePlayerBalance = _playerServices.ValidatePlayerBalance(validateBalancePlayerId);
                if (!validatePlayerBalance.Data)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = validatePlayerBalance.Message;
                    return transaction;
                }
                var validateBet = ValidateBet(createBet);
                if (!validateBet.Data)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = validateBet.Message;
                    return transaction;
                }
                var validateRouletteStatus = _rouletteServices.ValidateRouletteStatus(createBet.RouletteId);
                if (!validateRouletteStatus.Data)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = validateRouletteStatus.Message;
                    return transaction;
                }
                if (createBet.Prize > 10000)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = "La apuesta supera el valor permitido de 10000.";
                    return transaction;
                }
                var getBetTypeByCode = _betTypeServices.GetBetTypeByCode(createBet.BetType);
                if (getBetTypeByCode.Data.Id == 0)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = getBetTypeByCode.Message;
                    return transaction;
                }
                createBet.BetTypeId = getBetTypeByCode.Data.Id;
                var transCreateBet = _betServices.CreateBet(createBet);
                transaction.Status = (transCreateBet.Data.Flag) ? Common.Status.Success : Common.Status.Failure;
                transaction.Message = transCreateBet.Message;
                transaction.Data = transCreateBet.Data.Message;
            }
            catch (ArgumentException ex)
            {
                transaction.Status = Common.Status.Failure;
                transaction.Message = ex.Message;
            }

            return transaction;
        }

        private TransactionDTO<bool> ValidateBet(CreateBetDTO createBet)
        {
            ValidateBetDTO validateBet = new ValidateBetDTO();
            validateBet.RouletteId = createBet.RouletteId;
            validateBet.Bet = createBet.Bet;
            TransactionDTO<bool> transaction = new TransactionDTO<bool>();
            switch (createBet.BetType)
            {
                case CodeBet.Color:
                    transaction = _rouletteConfigurationServices.ValidateColorByRouletteId(validateBet);
                    break;
                case CodeBet.Number:
                    transaction = _rouletteConfigurationServices.ValidateNumberByRouletteId(validateBet);
                    break;
                default:
                    transaction.Message = "El tipo de apuesta escogido no es valido.";
                    transaction.Status = Common.Status.Failure;
                    transaction.Data = false;
                    break;
            }

            return transaction;
        }
    }
}
