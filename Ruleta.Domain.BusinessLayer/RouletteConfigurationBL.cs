using Ruleta.Domain.BusinessLayer.Interfaces;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Common.Models;
using Ruleta.Domain.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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
                List<RouletteConfigurationModel> listRouletteConfiguration = _rouletteConfigurationRepository.GetAllRouletteConfigurationByRoulette(rouletteId);
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
                transaction.Message = ex.Message;
            }

            return transaction;
        }

        public TransactionDTO<List<RouletteConfigurationDTO>> GetAllRouletteConfigurationByRoulette(long rouletteId)
        {
            TransactionDTO<List<RouletteConfigurationDTO>> transaction = new TransactionDTO<List<RouletteConfigurationDTO>>();
            transaction.Data = new List<RouletteConfigurationDTO>();
            try
            {
                var getAllRouletteConfigurationByRoullete = _rouletteConfigurationRepository.GetAllRouletteConfigurationByRoulette(rouletteId);
                if (getAllRouletteConfigurationByRoullete == null || getAllRouletteConfigurationByRoullete.Count == 0)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = "No fue posible obtener los registros de la configuración de la ruleta ruletas.";

                    return transaction;
                }
                foreach(var item in getAllRouletteConfigurationByRoullete){
                    RouletteConfigurationDTO rouletteConfiguration = new RouletteConfigurationDTO();
                    rouletteConfiguration.Id = item.Id;
                    rouletteConfiguration.Number = item.Number;
                    rouletteConfiguration.Color = item.Color;
                    rouletteConfiguration.Code = item.Code;
                    rouletteConfiguration.RouletteId = item.RouletteId;
                    transaction.Data.Add(rouletteConfiguration);
                }
            }
            catch (ArgumentException ex)
            {
                transaction.Status = Common.Status.Failure;
                transaction.Message = ex.Message;
            }

            return transaction;
        }

        public TransactionDTO<List<RouletteConfigurationDTO>> GetAllRouletteConfiguration()
        {
            TransactionDTO<List<RouletteConfigurationDTO>> transaction = new TransactionDTO<List<RouletteConfigurationDTO>>();
            transaction.Data = new List<RouletteConfigurationDTO>();
            try
            {
                var getAllRouletteConfigurationByRoullete = _rouletteConfigurationRepository.GetAllRouletteConfiguration();
                if (getAllRouletteConfigurationByRoullete == null || getAllRouletteConfigurationByRoullete.Count == 0)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = "No fue posible obtener los registros de la configuración de la ruleta ruletas.";

                    return transaction;
                }
                foreach (var item in getAllRouletteConfigurationByRoullete)
                {
                    RouletteConfigurationDTO rouletteConfiguration = new RouletteConfigurationDTO();
                    rouletteConfiguration.Id = item.Id;
                    rouletteConfiguration.Number = item.Number;
                    rouletteConfiguration.Color = item.Color;
                    rouletteConfiguration.Code = item.Code;
                    rouletteConfiguration.RouletteId = item.RouletteId;
                    transaction.Data.Add(rouletteConfiguration);
                }
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
