using Ruleta.Domain.BusinessLayer.Interfaces;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ruleta.Domain.BusinessLayer
{
    public class DocumentTypeBL: IDocumentTypeBL
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;
        public DocumentTypeBL(IDocumentTypeRepository documentTypeRepository) 
        {
            _documentTypeRepository = documentTypeRepository;
        }

        /// <summary>
        /// Method to get all the records from the DocumentType table
        /// </summary>
        /// <returns> List of records stored in table </returns>
        public List<DocumentTypeDTO> GetAllDocumentType()
        {
            try
            {
                List<DocumentTypeDTO> documentType = new List<DocumentTypeDTO>();
                var getDocumentType = _documentTypeRepository.GetAllDocumentType();
                if (getDocumentType == null || getDocumentType.Count == 0)
                {
                    return new List<DocumentTypeDTO>();
                }
                foreach (var item in getDocumentType)
                {
                    DocumentTypeDTO documentTypeDTO = new DocumentTypeDTO(item.Id, item.Name, item.Code);
                    documentType.Add(documentTypeDTO);
                }

                return documentType;
            }
            catch (ArgumentException ex)
            {

                return null;
            }
        }
    }
}
