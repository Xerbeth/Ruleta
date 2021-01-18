using Ruleta.Domain.BusinessLayer.Interfaces;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Common.Models;
using Ruleta.Domain.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace Ruleta.Domain.BusinessLayer
{
    public class RouletteBL : IRouletteBL
    {
        private readonly IRouletteRepository _rouletteRepository;
        public RouletteBL(IRouletteRepository rouletteRepository) 
        {
            _rouletteRepository = rouletteRepository;
        }

        /// <summary>
        /// Method to create roulette
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        public TransactionDTO<long> CreateRoulette()
        {
            TransactionDTO<long> transaction = new TransactionDTO<long>();
            transaction.Data = 0;
            try
            {
                RouletteModel rouletteModel = new RouletteModel();
                string name = RouletteNameGenerator();
                rouletteModel.Name = name;
                rouletteModel.Code = name;

                long createRouletteId = _rouletteRepository.CreateRoulette(rouletteModel);                
                if (createRouletteId < 0)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = "No fue posible crear la nueva ruleta de juego.";

                    return transaction;
                }
                transaction.Data = createRouletteId;
            }
            catch (ArgumentException ex)
            {
                transaction.Status = Common.Status.Failure;
                transaction.Message = ex.Message;
            }

            return transaction;
        }        

        /// <summary>
        /// Method to get all roulette records
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        public TransactionDTO<List<RouletteDTO>> GetAllRoulette()
        {
            TransactionDTO<List<RouletteDTO>> transaction = new TransactionDTO<List<RouletteDTO>>();
            transaction.Data = new List<RouletteDTO>(); 
            try
            {
                var getAllRoulette = _rouletteRepository.GetAllRoulette();
                if (getAllRoulette == null || getAllRoulette.Count == 0)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = "No fue posible obtener los registros de las ruletas.";

                    return transaction;
                }
                foreach (var item in getAllRoulette)
                {
                    RouletteDTO roulette = new RouletteDTO(item.Id, item.Name, item.Code, item.AllowBets);
                    transaction.Data.Add(roulette);
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
        /// Method to consult a roulette by identifier
        /// </summary>
        /// <param name="rouletteId"> roulette identifier </param>
        /// <returns> Object with the transaction information </returns>
        public TransactionDTO<RouletteDTO> GetRouletteById(string rouletteId)
        {
            TransactionDTO<RouletteDTO> transaction = new TransactionDTO<RouletteDTO>();
            transaction.Data = new RouletteDTO();
            try
            {
                var getRouletteById = _rouletteRepository.GetRouletteById(rouletteId);
                if (getRouletteById.Id == 0)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = "No existen la ruleta solicitada.";

                    return transaction;
                }
                transaction.Data = new RouletteDTO(getRouletteById.Id, getRouletteById.Name, getRouletteById.Code, getRouletteById.AllowBets);
            }
            catch (ArgumentException ex)
            {
                transaction.Status = Common.Status.Failure;
                transaction.Message = ex.Message;
            }

            return transaction;
        }

        /// <summary>
        /// Method to open roulette
        /// </summary>
        /// <param name="rouletteId"> roulette identifier </param>
        /// <returns> Object with the transaction information </returns>
        public TransactionDTO<bool> RouletteOpening(string rouletteId)
        {
            TransactionDTO<bool> transaction = new TransactionDTO<bool>();
            transaction.Data = true;
            try
            {
                var getRouletteById = GetRouletteById(rouletteId);
                if (getRouletteById.Data.Id == 0)
                {
                    transaction.Data = false;
                    transaction.Status = getRouletteById.Status;
                    transaction.Message = getRouletteById.Message;
                }

                bool rouletteOpening = _rouletteRepository.RouletteOpening(rouletteId);
                if (!rouletteOpening)
                {
                    transaction.Data = rouletteOpening;
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = "No fue posible realizar la apertura de la ruleta.";

                    return transaction;
                }               
            }
            catch (ArgumentException ex)
            {
                transaction.Data = false;
                transaction.Status = Common.Status.Failure;
                transaction.Message = ex.Message;
            }

            return transaction;
        }

        /// <summary>
        /// Private method to generate a roulette name
        /// </summary>
        /// <returns> Roulette name </returns>
        private string RouletteNameGenerator()
        {
            var getAllRoulette = GetAllRoulette();
            long number = getAllRoulette.Data.Count + 1;
            return "Ruleta" + number;
        }
    }
}
