using Ruleta.Domain.Common.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.BusinessLayer.Interfaces
{
    public interface IDocumentTypeBL
    {
        /// <summary>
        /// Method to get all the records from the DocumentType table
        /// </summary>
        /// <returns> List of records stored in table </returns>
        TransactionDTO<List<DocumentTypeDTO>> GetAllDocumentType();
    }
}
