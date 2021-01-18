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
        /// <summary>
        /// method to get the type of bet by the code of the bet
        /// </summary>
        /// <param name="code"> bet code </param>
        /// <returns> Object with the transaction information  </returns>
        public TransactionDTO<BetTypeDTO> GetBetTypeByCode(string code)
        {
            return _betTypeBL.GetBetTypeByCode(code);
        }
    }
}
