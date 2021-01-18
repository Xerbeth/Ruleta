using Ruleta.Domain.BusinessLayer.Interfaces;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.BusinessLayer
{
    public class BetBL : IBetBL
    {
        private readonly IBetRepository _betRepository;
        public BetBL(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }
        public TransactionDTO<MessageDTO> CreateBet(CreateBetDTO createBet)
        {
            TransactionDTO<MessageDTO> transaction = new TransactionDTO<MessageDTO>();
            transaction.Data = new MessageDTO();
            try
            {              
                long createRouletteId = _betRepository.CreateBet(createBet);
                if (createRouletteId < 0)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = "No fue posible crear la apuesta de juego.";

                    return transaction;
                }
                transaction.Data.Message = "¡Apuesta aceptada! :)";
                transaction.Data.Flag = true;
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
