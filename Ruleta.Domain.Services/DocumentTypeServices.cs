using Ruleta.Domain.BusinessLayer.Interfaces;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.Services
{
    public class DocumentTypeServices : IDocumentTypeServices
    {
        private readonly IDocumentTypeBL _documentTypeBL;

        public DocumentTypeServices(IDocumentTypeBL documentTypeBL)
        {
            _documentTypeBL = documentTypeBL;
        }
        /// <summary>
        /// Method to get all the records from the DocumentType table
        /// </summary>
        /// <returns> List of records stored in table </returns>
        public List<DocumentTypeDTO> GetAllDocumentType()
        {
            return _documentTypeBL.GetAllDocumentType();
        }
    }
}
