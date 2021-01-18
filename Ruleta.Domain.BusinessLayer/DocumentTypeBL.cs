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
        public TransactionDTO<List<DocumentTypeDTO>> GetAllDocumentType()
        {
            TransactionDTO<List<DocumentTypeDTO>> transaction = new TransactionDTO<List<DocumentTypeDTO>>();
            transaction.Data = new List<DocumentTypeDTO>();
            try
            {
                var getDocumentType = _documentTypeRepository.GetAllDocumentType();
                if (getDocumentType == null || getDocumentType.Count == 0)
                {
                    transaction.Status = Common.Status.Failure;
                    transaction.Message = "No existen datos en la base de datos para los tipos de documentos.";

                    return transaction;
                }
                foreach (var item in getDocumentType)
                {
                    DocumentTypeDTO documentTypeDTO = new DocumentTypeDTO(item.Id, item.Name, item.Code);
                    transaction.Data.Add(documentTypeDTO);
                }
            }
            catch (ArgumentException ex)
            {
                transaction.Status = Common.Status.Failure;
                transaction.Message = "Ocurrio un error consultando los datos de tipos de documentos.";
            }

            return transaction;
        }
    }
}
