using Ruleta.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.DAL.Repository.Interfaces
{
    public interface IBetTypeRepository
    {
        /// <summary>
        /// Method to get all the records from the BetType table
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        List<BetTypeModel> GetAllBetType();
    }
}
