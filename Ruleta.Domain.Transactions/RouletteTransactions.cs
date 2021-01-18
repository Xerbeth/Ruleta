using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Common.Models;
using Ruleta.Domain.Services.Interfaces;
using Ruleta.Domain.Transactions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Transactions;

namespace Ruleta.Domain.Transactions
{
    public class RouletteTransactions : IRouletteTransactions
    {
        private readonly IRouletteServices _rouletteServices;
        private readonly IRouletteConfigurationServices _rouletteConfigurationServices;

        public RouletteTransactions(IRouletteServices rouletteServices,
                                    IRouletteConfigurationServices rouletteConfigurationServices)
        {
            _rouletteServices = rouletteServices;
            _rouletteConfigurationServices = rouletteConfigurationServices;
        }

        public TransactionDTO<List<ListRouletteDTO>> GetRouletteConfiguration()
        {
            TransactionDTO<List<ListRouletteDTO>> getRouletteConfiguration = new TransactionDTO<List<ListRouletteDTO>>();
            try
            {
                var getAllRoulette = _rouletteServices.GetAllRoulette();
                if (getAllRoulette.Data.Count==0)
                {
                    getRouletteConfiguration.Message = getAllRoulette.Message;
                    getRouletteConfiguration.Status = getAllRoulette.Status;

                    return getRouletteConfiguration;
                }
                var getAllRouletteConfigurationByRoullete = _rouletteConfigurationServices.GetAllRouletteConfiguration();
                if (getAllRouletteConfigurationByRoullete.Data.Count == 0)
                {
                    getRouletteConfiguration.Message = getAllRouletteConfigurationByRoullete.Message;
                    getRouletteConfiguration.Status = getAllRouletteConfigurationByRoullete.Status;

                    return getRouletteConfiguration;
                }
                getRouletteConfiguration.Data = CombineRouletteAndConfiguration(getAllRoulette.Data, getAllRouletteConfigurationByRoullete.Data);
            }
            catch (Exception ex)
            {
                getRouletteConfiguration.Status = Common.Status.Failure;
                getRouletteConfiguration.Message = ex.Message;
            }

            return getRouletteConfiguration;
        }

        private List<ListRouletteDTO> CombineRouletteAndConfiguration(List<RouletteDTO> roulettes, List<RouletteConfigurationDTO> roulettesConfigurations)
        {
            var query = from roulette in roulettes
                    orderby roulette.Id
                    join roulettesConfiguration in roulettesConfigurations on roulette.Id equals roulettesConfiguration.RouletteId into conf
                    select new ListRouletteDTO
                    {
                        Id = roulette.Id,
                        Name = roulette.Name,
                        Code = roulette.Code,
                        AllowBets = roulette.AllowBets,
                        Configuration = (from confg in conf orderby confg.Id select confg).ToList()
                    };

            return query.ToList();
        }
    }
}
