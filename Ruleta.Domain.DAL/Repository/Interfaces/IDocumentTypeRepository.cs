using System;
using System.Collections.Generic;
using System.Text;
using Ruleta.Domain.Common.Models;

namespace Ruleta.Domain.DAL.Repository.Interfaces
{
    public interface IDocumentTypeRepository
    {
        List<DocumentTypeModel> GetAllDocumentType();
    }
}
