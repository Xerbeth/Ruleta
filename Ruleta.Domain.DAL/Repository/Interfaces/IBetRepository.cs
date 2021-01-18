using Ruleta.Domain.Common.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.DAL.Repository.Interfaces
{
    public interface IBetRepository
    {
        long CreateBet(CreateBetDTO createBet);
    }
}
