using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Saul.Test.Application.DTO;
using Saul.Test.Application.Interface.UseCases;
using Saul.Test.Transversal.Common;
using Swashbuckle.AspNetCore.Annotations;

namespace Saul.Test.Services.WebAPI.Controllers.v2
{
    [Authorize]
    [EnableRateLimiting("fixedWindow")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    [SwaggerTag("Get Categories of Products")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesApplication _categoriesApplication;
        private readonly ILoggerManager _logger;

        public CategoriesController(ICategoriesApplication categoriesApplication, ILoggerManager logger)
        {
            _categoriesApplication = categoriesApplication;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        [SwaggerOperation(
            Summary = "Get Categories",
            Description = "This endpoint will return all categories",
            OperationId = "GetAll",
            Tags = new string[] { "GetAll" })]
        [SwaggerResponse(200, "List of Categories", typeof(Response<IEnumerable<CategoryDto>>))]
        [SwaggerResponse(404, "Not found Categories")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoriesApplication.GetAll();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
