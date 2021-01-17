using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                return NoContent();
            }
        }
    }
}