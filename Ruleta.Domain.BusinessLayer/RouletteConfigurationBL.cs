using Ruleta.Domain.BusinessLayer.Interfaces;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Common.Models;
using Ruleta.Domain.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.BusinessLayer
{
    public class RouletteConfigurationBL : IRouletteConfigurationBL
    {
        private readonly IRouletteConfigurationRepository _rouletteConfigurationRepository;

        public RouletteConfigurationBL(IRouletteConfigurationRepository rouletteConfigurationRepository)
        {
            _rouletteConfigurationRepository = rouletteConfigurationRepository;
        }

        public TransactionDTO<bool> CreateRouletteConfiguration(long rouletteId)
        {
            TransactionDTO<bool> transaction = new TransactionDTO<bool>();
            transaction.Data = false;
            try
            {
                List<RouletteConfigurationModel> listRouletteConfiguration = _rouletteConfigurationRepository.GetAllRouletteConfigurationByRoullete(rouletteId);
                if (listRouletteConfiguration.Count > 0)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = "Ya existen registro activos de la configuración de la ruleta.";

                    return transaction;
                }

                _rouletteConfigurationRepository.CreateRouletteConfiguration(rouletteId);
                transaction.Data = true;
            }
            catch (ArgumentException ex)
            {
                transaction.Status = Common.Status.Failure;
                transaction.Message = "Ocurrio un error creando la ruleta de juega.";
            }

            return transaction;
        }

        public TransactionDTO<List<RouletteConfigurationModel>> GetAllRouletteConfigurationByRoullete(long rouletteId)
        {
            TransactionDTO<List<RouletteConfigurationModel>> transaction = new TransactionDTO<List<RouletteConfigurationModel>>();
            transaction.Data = new List<RouletteConfigurationModel>();
            try
            {
                var getAllRoulette = _rouletteConfigurationRepository.GetAllRouletteConfigurationByRoullete(rouletteId);
                if (getAllRoulette == null || getAllRoulette.Count == 0)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = "No fue posible obtener los registros de la configuración de la ruleta ruletas.";

                    return transaction;
                }
                transaction.Data = getAllRoulette;
            }
            catch (ArgumentException ex)
            {
                transaction.Status = Common.Status.Failure;
                transaction.Message = "Ocurrio un error consultando los registros de la configuración de la ruleta ruletas.";
            }

            return transaction;
        }
    }
}
