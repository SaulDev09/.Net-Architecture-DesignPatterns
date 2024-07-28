using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saul.Test.Application.Interface;
using Saul.Test.Transversal.Common;

namespace Saul.Test.Services.WebAPI.Controllers.v2
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
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
