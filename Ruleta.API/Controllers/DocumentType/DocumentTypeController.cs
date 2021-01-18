using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ruleta.Domain.Common.DataTransferObject;
using Ruleta.Domain.Services.Interfaces;

namespace Ruleta.API.Controllers.DocumentType
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        readonly IDocumentTypeServices _documentTypeServices;
        public DocumentTypeController(IDocumentTypeServices documentTypeServices)
        {
            _documentTypeServices = documentTypeServices;
        }

        /// <summary>
        /// Method to get all the records from the DocumentType table
        /// </summary>
        /// <returns> Object with the transaction information </returns>
        [HttpGet("GetAllDocumentType")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAllDocumentType()
        {
            try
            {
                return Ok(_documentTypeServices.GetAllDocumentType());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorAnswerDTO()
                {
                    State = StatusCodes.Status400BadRequest,
                    Mistakes = new List<ErrorDTO>(new[]
                    {
                         new ErrorDTO()
                         {
                             Code = "",
                             Description = ex.Message
                         }
                     })
                });
            }
        }
    }
}