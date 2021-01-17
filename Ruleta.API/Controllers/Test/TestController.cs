using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ruleta.Domain.Services.Interfaces;

namespace Ruleta.API.Controllers.Test
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestServices _testServices;

        public TestController(ITestServices testServices)
        {
            _testServices = testServices;
        }

        [HttpGet("HelloWordl")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult HelloWordl()
        {
            try
            {
                return Ok(_testServices.GetMessage("Jugador")); 
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }
    }
}