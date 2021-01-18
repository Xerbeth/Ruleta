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
                transaction.Message = "Ocurrio un error creando la ruleta de juega.";
            }

            return transaction;
        }        

        /// <summary>
        /// Method to get all roulette records
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        public TransactionDTO<List<RouletteModel>> GetAllRoulette()
        {
            TransactionDTO<List<RouletteModel>> transaction = new TransactionDTO<List<RouletteModel>>();
            transaction.Data = new List<RouletteModel>(); 
            try
            {
                var getAllRoulette = _rouletteRepository.GetAllRoulette();
                if (getAllRoulette == null || getAllRoulette.Count == 0)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = "No fue posible obtener los registros de las ruletas.";

                    return transaction;
                }
                transaction.Data = getAllRoulette;
            }
            catch (ArgumentException ex)
            {
                transaction.Status = Common.Status.Failure;
                transaction.Message = "Ocurrio un error consultando los registros de las ruletas.";
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
