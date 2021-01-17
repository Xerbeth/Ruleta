using Ruleta.Domain.Common.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Services.Interfaces
{
    public interface IDocumentTypeServices
    {
        /// <summary>
        /// Method to get all the records from the DocumentType table
        /// </summary>
        /// <returns> List of records stored in table </returns>
        List<DocumentTypeDTO> GetAllDocumentType();
    }
}
