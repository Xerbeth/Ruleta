﻿using Ruleta.Domain.BusinessLayer.Interfaces;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.BusinessLayer
{
    public class BetTypeBL : IBetTypeBL
    {
        private IBetTypeRepository _betTypeRepository; 

        public BetTypeBL(IBetTypeRepository betTypeRepository)
        {
            _betTypeRepository = betTypeRepository;
        }

        /// <summary>
        /// Method to get all the records from the BetType table
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        public TransactionDTO<List<BetTypeDTO>> GetAllBetType()
        {
            TransactionDTO<List<BetTypeDTO>> transaction = new TransactionDTO<List<BetTypeDTO>>();
            transaction.Data = new List<BetTypeDTO>();
            try
            {                
                var getDocumentType = _betTypeRepository.GetAllBetType();
                if (getDocumentType == null || getDocumentType.Count == 0)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = "No existen datos en la base de datos para los tipos de apuestas.";

                    return transaction;
                }
                foreach (var item in getDocumentType)
                {
                    BetTypeDTO betTypeDTO = new BetTypeDTO(item.Id, item.Name, item.Code, item.Description, item.Pay);
                    transaction.Data.Add(betTypeDTO);
                }                
            }
            catch (ArgumentException ex)
            {
                transaction.Status = Common.Status.Failure;
                transaction.Message = ex.Message;
            }

            return transaction;
        }

        /// <summary>
        /// method to get the type of bet by the code of the bet
        /// </summary>
        /// <param name="code"> bet code </param>
        /// <returns> Object with the transaction information  </returns>
        public TransactionDTO<BetTypeDTO> GetBetTypeByCode(string code)
        {
            TransactionDTO<BetTypeDTO> transaction = new TransactionDTO<BetTypeDTO>();
            transaction.Data = new BetTypeDTO();
            try
            {
                var getBetTypeByCode = _betTypeRepository.GetBetTypeByCode(code);
                if (getBetTypeByCode.Id == 0)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = "No existen datos en la base de datos el tipo de apuesta escodigo.";

                    return transaction;
                }
                transaction.Data.Id = getBetTypeByCode.Id;
                transaction.Data.Name = getBetTypeByCode.Name;
                transaction.Data.Description = getBetTypeByCode.Description;
                transaction.Data.Pay = getBetTypeByCode.Pay;
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
