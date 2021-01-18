using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Common.Models;
using Ruleta.Domain.Services.Interfaces;
using Ruleta.Domain.Transactions.Interfaces;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Method to create roulette
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        public TransactionDTO<long> CreateRoulette()
        {
            TransactionDTO<long> createRoulette = new TransactionDTO<long>();
            TransactionDTO<bool> rouletteConfiguration = new TransactionDTO<bool>();

            using (TransactionScope scope1 = new TransactionScope())
            //Default is Required
            {
                using (TransactionScope scope2 = new TransactionScope(TransactionScopeOption.Required))
                {
                    createRoulette = _rouletteServices.CreateRoulette();
                }

                //using (TransactionScope scope3 = new TransactionScope(TransactionScopeOption.RequiresNew))
                //{
                //    TransactionDTO<List<RouletteConfigurationModel>> getAllRouletteConfigurationByRoullete = _rouletteConfigurationServices.GetAllRouletteConfigurationByRoullete(createRoulette.Data);
                //    if (getAllRouletteConfigurationByRoullete.Data.Count > 0)
                //    {
                //        createRoulette.Message = "No es posible crear la ruleta debido a que ya existe el identificador de la misma.";
                //        createRoulette.Status = Common.Status.Failure;
                //        return createRoulette;
                //    }

                //    rouletteConfiguration = _rouletteConfigurationServices.CreateRouletteConfiguration(createRoulette.Data);
                //    if (rouletteConfiguration.Data == null || !rouletteConfiguration.Data)
                //    {
                //        rouletteConfiguration.Message = "Ocurrió un error creando la configuración de la ruleta.";
                //        rouletteConfiguration.Status = Common.Status.Failure;
                //    }
                //}
                scope1.Complete();
            }
            return createRoulette;
        }














        //try
        //{
        //    using (TransactionScope scope = new TransactionScope())
        //    {
        //        createRoulette = _rouletteServices.CreateRoulette();
        //        TransactionDTO<List<RouletteConfigurationModel>> getAllRouletteConfigurationByRoullete = _rouletteConfigurationServices.GetAllRouletteConfigurationByRoullete(createRoulette.Data);
        //        if (getAllRouletteConfigurationByRoullete.Data.Count > 0)
        //        {
        //            createRoulette.Message = "No es posible creo que la ruleta debido a que ya existe el identificador de la misma.";
        //            createRoulette.Status = Common.Status.Failure;
        //            return createRoulette;
        //        }
        //        scope.Complete();
        //    }
        //}
        //catch (TransactionAbortedException ex)
        //{
        //    createRoulette.Status = Common.Status.Failure;
        //    createRoulette.Message = "Ocurrió un error al momento de crear la ruleta de juego.";
        //}

        //return createRoulette;
        //}
    }
}
