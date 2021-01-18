using Ruleta.Domain.BusinessLayer.Interfaces;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Services
{
    public class BetTypeServices : IBetTypeServices
    {
        private readonly IBetTypeBL _betTypeBL;

        public BetTypeServices(IBetTypeBL betTypeBL)
        {
            _betTypeBL = betTypeBL;
        }

        /// <summary>
        /// Method to get all the records from the BetType table
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        public TransactionDTO<List<BetTypeDTO>> GetAllBetType()
        {
            return _betTypeBL.GetAllBetType();
        }
    }
}
